using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Data.SqlClient;
using HRApplicantSystem.Models;

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
                    var parts = line.Split('=');
                    config[parts[0].Trim()] =
                        parts[1].Trim();
                }
            }
            _connectionString =
                $"Server=tcp:{config["server"]},1433;" +
                $"Initial Catalog={config["database"]};" +
                $"User ID={config["user"]};" +
                $"Password={config["password"]};" +
                "Encrypt=True;" +
                "TrustServerCertificate=False;" +
                "Connection Timeout=30;";
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }

    // ─────────────────────────────────────────
    // SESSION MANAGER
    // ─────────────────────────────────────────
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }
        public static string CurrentRole { get; set; }
        public static HRApplicantSystem.Models.Applicant CurrentApplicant { get; set; }

        public static void Login(User user)
        {
            CurrentUser = user;
            CurrentRole = user.Role;
        }

        public static void LoginApplicant(Applicant applicant)
        {
            CurrentApplicant = applicant;
        }

        public static void Logout()
        {
            CurrentUser = null;
            CurrentRole = null;
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
            return !string.IsNullOrEmpty(email)
                   && email.Contains("@")
                   && email.Contains(".");
        }

        public static bool IsPasswordStrong(string password)
        {
            return !string.IsNullOrEmpty(password)
                   && password.Length >= 6;
        }

        public static bool IsFieldEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }

    // ─────────────────────────────────────────
    // AUDIT LOGGER
    // ─────────────────────────────────────────
    public static class AuditLogger
    {
        public static void LogAction(
            int userId, string action,
            string target, int targetId)
        {
            try
            {
                using (var conn =
                    DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO audit_logs
                            (user_id, action,
                             target, target_id)
                        VALUES
                            (@userId, @action,
                             @target, @targetId)";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue(
                        "@userId", userId);
                    cmd.Parameters.AddWithValue(
                        "@action", action);
                    cmd.Parameters.AddWithValue(
                        "@target", target);
                    cmd.Parameters.AddWithValue(
                        "@targetId", targetId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }
    }

    // ─────────────────────────────────────────
    // STATUS HISTORY LOGGER
    // ─────────────────────────────────────────
    public static class StatusHistoryLogger
    {
        public static void LogStatusChange(
            int applicationId, string oldStatus,
            string newStatus, int changedBy,
            string remarks)
        {
            try
            {
                using (var conn =
                    DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO status_history
                            (application_id, old_status,
                             new_status, changed_by,
                             remarks)
                        VALUES
                            (@appId, @old,
                             @new, @by, @remarks)";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue(
                        "@appId", applicationId);
                    cmd.Parameters.AddWithValue(
                        "@old", oldStatus);
                    cmd.Parameters.AddWithValue(
                        "@new", newStatus);
                    cmd.Parameters.AddWithValue(
                        "@by", changedBy);
                    cmd.Parameters.AddWithValue(
                        "@remarks", remarks ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }
    }
}
