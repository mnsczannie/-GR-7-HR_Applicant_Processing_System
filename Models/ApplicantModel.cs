using System;
namespace HRApplicantSystem.Models
{
    public class Applicant
    {
        public int ApplicantId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
        public string School { get; set; }
        public string Degree { get; set; }
        public string YearGrad { get; set; }
        public string Skills { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Duration { get; set; }
        public bool IsActive { get; set; }
    }

    public class Application
    {
        public int ApplicationId { get; set; }
        public int ApplicantId { get; set; }
        public int VacancyId { get; set; }
        public string Status { get; set; }
        public DateTime? SubmittedAt { get; set; }
    }

    public class ApplicantDocument
    {
        public int DocId { get; set; }
        public int ApplicantId { get; set; }
        public int ReqTypeId { get; set; }
        public string FilePath { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
    }
}