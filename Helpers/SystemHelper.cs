using HRApplicantSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace HRApplicantSystem.Helpers
{
    // ─────────────────────────────────────────
    // DATABASE HELPER
    // ─────────────────────────────────────────
    public static class DatabaseHelper
    {
        private static string _connectionString;

        public static void LoadConfig(string iniPath)
        {
            var config = new Dictionary<string, string>();
            foreach (var line in File.ReadAllLines(iniPath))
            {
                if (line.Contains("="))
                {
                    var parts = line.Split(new char[] { '=' }, 2);

                    config[parts[0].Trim()] = parts[1].Trim();
                }
            }

            _connectionString =
                $"Server=tcp:{config["server"]},1433;" +
                $"Initial Catalog={config["database"]};" +
                $"Persist Security Info=False;" +
                $"User ID={config["user"]};" +
                $"Password={config["password"]};" +
                $"MultipleActiveResultSets=False;" +
                $"Encrypt=True;" +
                $"TrustServerCertificate=False;" +
                $"Connection Timeout=30;";
        }

        /// <summary>
        /// Returns an UNOPENED SqlConnection.
        /// Callers must call conn.Open() themselves (or use using + Open).
        /// </summary>
        public static SqlConnection GetConnection()
        {
            if (string.IsNullOrEmpty(_connectionString))
                throw new InvalidOperationException(
                    "Database config not loaded. Call DatabaseHelper.LoadConfig() first.");

            return new SqlConnection(_connectionString);
        }
    }

    // ─────────────────────────────────────────
    // SESSION MANAGER
    // ─────────────────────────────────────────
    public static class SessionManager
    {
        public static User CurrentUser { get; private set; }
        public static string CurrentRole => CurrentUser?.Role;

        public static int CurrentUserID => CurrentUser?.UserId ?? 0;
        public static Applicant CurrentApplicant { get; private set; }

        public static bool IsLoggedIn => CurrentUser != null;

        public static void Login(User user)
        {
            CurrentUser = user;
        }

        public static void LoginApplicant(Applicant applicant)
        {
            CurrentApplicant = applicant;
        }

        public static void Logout()
        {
            CurrentUser = null;
            CurrentApplicant = null;
        }
    }

    // ─────────────────────────────────────────
    // VALIDATION HELPER
    // ─────────────────────────────────────────
    public static class ValidationHelper
    {
        public static bool IsEmailValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return Regex.IsMatch(email.Trim(),
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase);
        }

        public static bool IsPasswordStrong(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6) return false;
            return true;
        }

        public static bool IsFieldEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsEmailTaken(string email)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        "SELECT COUNT(1) FROM users WHERE email = @Email", conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email.Trim().ToLower());
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch
            {
                return true;
            }
        }
    }

    // ─────────────────────────────────────────
    // AUDIT LOGGER
    // ─────────────────────────────────────────
    public static class AuditLogger
    {
        // The audit trail on the dashboard joins audit_logs.user_id to
        // applicants.applicant_id, so every applicant-side log call needs
        // the applicant_id (not a users.user_id) passed in as userId.
        // This looks that up from the email the form already has on hand.
        public static int? GetApplicantIdByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return null;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        "SELECT applicant_id FROM applicants WHERE email = @Email", conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email.Trim());
                        object result = cmd.ExecuteScalar();
                        return result == null ? (int?)null : Convert.ToInt32(result);
                    }
                }
            }
            catch
            {
                // Swallow lookup failures: a missing audit log entry should
                // never block the actual action (save, password change, etc).
                return null;
            }
        }

        public static void LogAction(int userId, string action,
    string target, int? targetId = null)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"
                        INSERT INTO audit_logs
                            (user_id, action, target, target_id, performed_at)
                        VALUES
                            (@userId, @action, @target, @targetId, @performedAt)";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@action", action ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@target", target ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@targetId", (object)targetId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@performedAt", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Audit failures should never block login or any other action
            }
        }

        // Convenience overload for applicant-side forms, which only carry
        // the applicant's email around (not their applicant_id). Resolves
        // the ID first, then logs. If the lookup fails, the action itself
        // still isn't blocked -- we just skip the audit entry.
        public static void LogActionByEmail(string applicantEmail, string action,
            string target, int? targetId = null)
        {
            int? applicantId = GetApplicantIdByEmail(applicantEmail);
            if (applicantId.HasValue)
            {
                LogAction(applicantId.Value, action, target, targetId);
            }
        }
    }

    // ─────────────────────────────────────────
    // STATUS HISTORY LOGGER
    // ─────────────────────────────────────────
    public static class StatusHistoryLogger
    {
        public static void LogStatusChange(int applicationId, string previousStatus,
            string newStatus, int changedByUserId, string remarks = null)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var tx = conn.BeginTransaction();
                    try
                    {
                        string insertSql = @"
                            INSERT INTO status_history
                                (application_id, changed_by, old_status,
                                 new_status, remarks, changed_at)
                            VALUES
                                (@appId, @changedBy, @oldStatus,
                                 @newStatus, @remarks, @changedAt)";

                        using (var cmd = new SqlCommand(insertSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@appId", applicationId);
                            cmd.Parameters.AddWithValue("@changedBy", changedByUserId);
                            cmd.Parameters.AddWithValue("@oldStatus", previousStatus ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@newStatus", newStatus);
                            cmd.Parameters.AddWithValue("@remarks", (object)remarks ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@changedAt", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }

                        string updateSql = @"
                            UPDATE applications
                            SET status = @newStatus, last_updated = @now
                            WHERE application_id = @appId";

                        using (var cmd = new SqlCommand(updateSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@newStatus", newStatus);
                            cmd.Parameters.AddWithValue("@now", DateTime.Now);
                            cmd.Parameters.AddWithValue("@appId", applicationId);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();

                        AuditLogger.LogAction(
                            changedByUserId,
                            $"Status changed from '{previousStatus}' to '{newStatus}'",
                            "applications",
                            applicationId
                        );
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    $"StatusHistoryLogger error: {ex.Message}", ex);
            }
        }
    }
}