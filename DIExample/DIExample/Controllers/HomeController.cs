using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesService _citiesService;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        

        //Constructor to create obj cityservice class
        public HomeController(ICitiesService citiesService, IServiceScopeFactory serviceScopeFactory)
        {
            _citiesService = citiesService;  //new CitiesService();
            _serviceScopeFactory = serviceScopeFactory;
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> Cities = _citiesService.GetCities();
            //using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            //{
            //    ICitiesService citiesService = scope.ServiceProvider.GetRequiredService<ICitiesService>();
            //    List<string> Cities = citiesService.GetCities();
            //    return View(Cities);
            //}
            
            return View(Cities);
        }
    }
}
