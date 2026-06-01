namespace HRApplicantSystem.Models
{
    public class JobVacancy
    {
        public int VacancyId { get; set; }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        public int EmploymentTypeId { get; set; }
        public string Description { get; set; }
        public string Qualifications { get; set; }
        public int Slots { get; set; }
        public string Status { get; set; }
    }

    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
    }
}
