using ControllersExample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    //[Authorize]
    public class LoginController : Controller
    {
        //[Route("bookstore")]
        //url : /bookstore?bookid=10&isloggedin=true
        [Route("bookstore/{bookid?}/{isloggedin?}/{author?}")]
        public IActionResult Index(int? bookId, bool? isLoggedIn, Book book)
        {
            if (bookId.HasValue == false)
            {
                /*Response.StatusCode= 400;
                return Content("Id not entered. Please enter valid Id");*/
                return BadRequest("Id not entered. Please enter valid Id");
            }

            if (isLoggedIn == false || !isLoggedIn.HasValue)
            {
                /*Response.StatusCode = 401;
                return Content("User not loggedin");*/
                return Unauthorized("User not loggedin");
            }

            if (bookId <= 0)
            {
                return Content("Id should be greater than 1");
            }
            if(bookId > 1000)
            {
                return Content("Id should be less than or equal to 1000");
            }

            return Content($"Book Id : {bookId}\n{book}") ;
        }
    }
}
