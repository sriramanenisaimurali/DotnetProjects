using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace CRUDExample.Controllers
{
    [Route("[controller]")]
    public class PersonsController : Controller
    {
        //Private fields
        private readonly IPersonsService _personsService;
        private readonly ICountriesService _countriesService;

        //Constructor
        public PersonsController(IPersonsService personsService, ICountriesService countriesService)
        {
            _personsService = personsService;
            _countriesService = countriesService;
        }

        [Route("/")]
        [Route("[action]")]
        //[Route("~/persons/indexs")]
        public async Task<IActionResult> Index(string searchBy, string searchString, string sortBy = nameof(PersonResponse.PersonName), SortOrderOptions sortOrder = SortOrderOptions.ASC )
        {
            ViewBag.SearchFields = new Dictionary<string, string>()
            {
                {nameof(PersonResponse.PersonName), "Person Name" },
                {nameof(PersonResponse.Email), "Email" },
                {nameof(PersonResponse.DateOfBirth), "Date of birth" },
                {nameof(PersonResponse.Age), "Age" },
                {nameof(PersonResponse.Gender), "Gender" },
                {nameof(PersonResponse.CountryName), "Country Name" },
                {nameof(PersonResponse.Address), "Address" },
                {nameof(PersonResponse.ReceiveNewsLetters), "Receiving news letters" }
            };
            List<PersonResponse> allPersons = await _personsService.GetFilteredPersons(searchBy, searchString);
            ViewBag.CurrentSearchBy = searchBy;
            ViewBag.CurrentSearchString = searchString;

            //sorting
            List<PersonResponse> sortedAllPersons = await _personsService.GetSortedPersonsList(allPersons, sortBy, sortOrder);
            ViewBag.CurrentSortBy=sortBy;
            ViewBag.CurrentSortOrder=sortOrder.ToString();

            return View(sortedAllPersons);
        }


        //Executes when user clicks on "Create Person" HyperLink
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<CountryResponse> Countries = await _countriesService.GetAllCountiesList();
            ViewBag.Countries = Countries.Select(temp => new SelectListItem(temp.CountryName, temp.CountryId.ToString()));
            return View();
        }


        //Executes when user clicks on Submit button on Create view form.
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Create(PersonAddRequest personAddRequest)
        {
            if(!ModelState.IsValid)
            {
                List<CountryResponse> Countries = await _countriesService.GetAllCountiesList();
                ViewBag.Countries = Countries.Select(temp => new SelectListItem(temp.CountryName, temp.CountryId.ToString()));
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return View();
            }

            PersonResponse personResonse = await _personsService.AddPerson(personAddRequest);
            return RedirectToAction("Index", "Persons");
        }


        //Executes when user clicks on edit button in index page.
        [Route("[action]/{personId}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid personId)
        {
            PersonResponse? personResponse = await _personsService.GetPersonDetailsByPersonId(personId);
            if(personResponse == null)
            {
                return RedirectToAction("Index");
            }
            PersonUpdateRequest personUpdateRequest  = personResponse.ToPersonUpdateRequest();
            List<CountryResponse> Countries = await _countriesService.GetAllCountiesList();
            ViewBag.Countries = Countries.Select(temp => new SelectListItem(temp.CountryName, temp.CountryId.ToString()));
            return View(personUpdateRequest);
        }

        //Executes when user updates specified person details
        [HttpPost]
        [Route("[action]/{personId}")]
        public async Task<IActionResult> Edit(PersonUpdateRequest personUpdateRequest, Guid personId)
        {
            PersonResponse? personResponseDetails = await _personsService.GetPersonDetailsByPersonId(personId);
            if(personResponseDetails == null)
            {
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                List<CountryResponse> Countries = await _countriesService.GetAllCountiesList();
                ViewBag.Countries = Countries.Select(temp => new SelectListItem(temp.CountryName, temp.CountryId.ToString()));
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return View();
            }

            PersonResponse personResponse = await _personsService.UpdatePersonDetails(personUpdateRequest);

            return RedirectToAction("Index");
        }

        //Executes when user wants to delete a specific record.
        [HttpGet]
        [Route("[action]/{personId}")]
        public async Task<IActionResult> Delete(Guid personId)
        {
            PersonResponse? personseResponse = await _personsService.GetPersonDetailsByPersonId(personId);
            if(personseResponse == null)
            {
                return RedirectToAction("Index");
            }

            List<CountryResponse> Countries = await _countriesService.GetAllCountiesList();
            ViewBag.Countries = Countries.Select(temp => new SelectListItem(temp.CountryName, temp.CountryId.ToString()));

            return View(personseResponse);
        }

        [HttpPost]
        [Route("[action]/{personId}")]
        public async Task<IActionResult> Delete(PersonUpdateRequest personUpdateRequest,Guid personId)
        {
            PersonResponse? personseResponse = await _personsService.GetPersonDetailsByPersonId(personId);
            if (personseResponse == null)
            {
                return RedirectToAction("Index");
            }

            await _personsService.DeletePerson(personId);
            return RedirectToAction("Index");
        }
    }
}
