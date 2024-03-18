using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;

namespace ViewsExample.ViewComponents
{
    public class EmployeeGridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            EmployeeGridModel employeeGridModel = new EmployeeGridModel()
            {
                GridTitle = "Emploayee Data",
                Employees = new List<Employee>()
                {
                    new Employee()
                    {
                        Name = "Jeevan",
                        Domain = "Software Developer"
                    },
                    new Employee()
                    {
                        Name = "Rahul",
                        Domain = "Business Analyst"
                    },
                    new Employee()
                    {
                        Name = "Mohan",
                        Domain = "Testing"
                    }
                }
            };
            ViewData["Grid"] = employeeGridModel;
            return View("EmployeeGrid");
        }
    }
}
