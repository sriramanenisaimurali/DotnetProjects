using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using System.Reflection;
using ControllersExample.Models;

namespace ControllersExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("index")]
        [Route("/")]
        public string Index()
        {
            return ("Hello from Index page");
        }

        [Route("about")]
        public ContentResult about()
        {
            return Content("Hello from about page Using <h5>Content return type</h5>","text/html");
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        public string contact()
        {
            return ("Hello from contact-us page");
        }


        /*[Route("person")]
        public JsonResult person()
        {
            Person person = new Person() 
            { Id =Guid.NewGuid(), firstName = "sai", lastName = "Murali", age = 23  };
            return Json(person);
        }*/
    }
}
