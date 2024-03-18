using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;

namespace ViewsExample.controllers
{
    public class ProductsController : Controller
    {
        [Route("/Products")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("electronics")]
        public IActionResult Electronics()
        {
            ListModel objListModel = new ListModel();
            objListModel.ListName = "Electronics";
            objListModel.ListItems = new List<string>()
            {
                "Laptops", "Headphones", "Refrigerators", "Washing Machines"
            };
            return PartialView("_ListPartialView", objListModel);
        }
    }
}
