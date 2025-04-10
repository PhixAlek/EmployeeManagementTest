namespace EmployeeManagementTest.Business.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public int EmployeeAge { get; set; }
        public decimal Salary { get; set; }
        public SalaryType SalaryType { get; set; } = SalaryType.Monthly;
        public string ProfileImage { get; set; } = string.Empty;

        public decimal EmployeeAnnualSalary =>
            SalaryType == SalaryType.Annual ? Salary :
            SalaryType == SalaryType.Monthly ? Salary * 12 :
            SalaryType == SalaryType.Hourly ? Salary * 160 * 12 : 0;
    }

    public enum SalaryType
    {
        Monthly,
        Annual,
        Hourly
    }
}
