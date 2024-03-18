using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;

namespace ControllersExample.Controllers
{
    public class RegistrationController : Controller
    {
        [Route("register/person")]
        public IActionResult Index(Person person)
        {
            if(!ModelState.IsValid)
            {
                string errors = string.Join("\n",
                ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage).ToList());
                
                return BadRequest(errors);
            }

            return Content($"{person}");
        }
    }
}
