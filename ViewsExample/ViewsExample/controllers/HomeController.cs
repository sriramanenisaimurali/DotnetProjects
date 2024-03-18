using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;

namespace ViewsExample.controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Home()
        {
            return View();
        }

        [Route("/person")]
        public IActionResult Index()
        {
            List<Person> peopleList = new List<Person>()
            {
                new Person()
                {
                    Name = "Prashant",
                    DateOfBirth = DateTime.Parse("1998-07-31"),
                    PersonGender = Gender.Male
                },
                new Person()
                {
                    Name = "Pradeep",
                    DateOfBirth = DateTime.Parse("1995-09-13"),
                    PersonGender = Gender.Male
                },
                new Person()
                {
                    Name = "Rini Clara",
                    DateOfBirth = DateTime.Parse("1995-02-28"),
                    PersonGender = Gender.Female
                }
            };
            //ViewData["people"] = peopleList; //viewData Example
            //ViewBag.people = peopleList;
            return View(peopleList);
        }

        [Route("/personal-details/{name}")]
        public IActionResult PersonDetails(string? name)
        {
            if (name == null)
            {
                return Content("Invalid URL");
            }

            List<Person> peopleList = new List<Person>()
            {
                new Person()
                {
                    Name = "Prashant",
                    DateOfBirth = DateTime.Parse("1998-07-31"),
                    PersonGender = Gender.Male
                },
                new Person()
                {
                    Name = "Pradeep",
                    DateOfBirth = DateTime.Parse("1995-09-13"),
                    PersonGender = Gender.Male
                },
                new Person()
                {
                    Name = "Rini Clara",
                    DateOfBirth = DateTime.Parse("1995-02-28"),
                    PersonGender = Gender.Female
                }
            };
            Person? MatchingPerson = peopleList.Where(temp => temp.Name == name).FirstOrDefault();
            
            if(MatchingPerson == null)
            {
                return Content("Invalid URL");
            }
            return View(MatchingPerson);
        }

        [Route("/about-company")]
        public IActionResult About()
        {
            return View();
        }
    }
}
