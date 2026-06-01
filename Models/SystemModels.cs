using System;
namespace HRApplicantSystem.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }

    public class StatusHistory
    {
        public int HistoryId { get; set; }
        public int ApplicationId { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public int ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; }
        public string Remarks { get; set; }
    }

    public class AuditLog
    {
        public int LogId { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; }
        public string Target { get; set; }
        public int TargetId { get; set; }
        public DateTime PerformedAt { get; set; }
    }
}
