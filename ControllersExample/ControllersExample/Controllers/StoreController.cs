using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/book")]
        public IActionResult Books()
        {
            return File("/docs.pdf", "application/pdf");
        }
    }
}
