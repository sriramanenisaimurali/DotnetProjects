namespace ViewsExample.Models
{
    public class EmployeeGridModel
    {
        public string? GridTitle { get; set; }
        public List<Employee> Employees { get; set;} = new List<Employee>();
    }
}
