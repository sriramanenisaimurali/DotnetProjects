using Microsoft.AspNetCore.Mvc;

namespace ViewsExample.controllers
{
    public class Employee : Controller
    {
        [Route("/employee-data")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
