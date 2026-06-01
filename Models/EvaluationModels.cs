using System;
namespace HRApplicantSystem.Models
{
    public class ScreeningResult
    {
        public int ScreeningId { get; set; }
        public int ApplicationId { get; set; }
        public int ReviewedBy { get; set; }
        public string Result { get; set; }
        public string Remarks { get; set; }
    }

    public class InterviewSchedule
    {
        public int ScheduleId { get; set; }
        public int ApplicationId { get; set; }
        public int InterviewerId { get; set; }
        public int InterviewTypeId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public TimeSpan ScheduledTime { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
    }

    public class InterviewEvaluation
    {
        public int EvaluationId { get; set; }
        public int ScheduleId { get; set; }
        public int ApplicationId { get; set; }
        public decimal Score { get; set; }
        public string Remarks { get; set; }
        public string Result { get; set; }
        public string Recommendation { get; set; }
    }

    public class HiringDecision
    {
        public int DecisionId { get; set; }
        public int ApplicationId { get; set; }
        public string FinalDecision { get; set; }
        public string Remarks { get; set; }
        public int DecidedBy { get; set; }
    }
}
