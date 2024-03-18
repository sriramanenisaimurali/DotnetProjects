using Entities;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services.Helpers;


namespace Services
{
    public class PersonsService : IPersonsService
    {
        private readonly PersonsDbContext _db;
        private readonly ICountriesService _countriesService;
        public PersonsService(PersonsDbContext personsDbContext,ICountriesService countriesService)
        {
            _db= personsDbContext;
            _countriesService = countriesService;
            
        }


        /// <summary>
        /// This method add a person and return details of added person
        /// </summary>
        /// <param name="personAddRequest">Argument used for sending request to AddPerson</param>
        /// <returns>Returns a PersonResponse of added person in the list</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<PersonResponse> AddPerson(PersonAddRequest? personAddRequest)
        {
            //check if PersonAddRequest is Not Null
            if(personAddRequest == null)
            {
                throw new ArgumentNullException(nameof(personAddRequest));
            }

            //Model Validations
            ValidationHelper.ModelValidation(personAddRequest);

            //User enters proper values
            Person person = personAddRequest.ToPerson();
            person.PersonId = Guid.NewGuid();
            _db.Persons.Add(person);
            await _db.SaveChangesAsync();

            return person.ToPersonResponse();
        }

        /// <summary>
        /// This used for fetching all person details
        /// </summary>
        /// <returns>Returns all person details in the list</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<PersonResponse>> GetAllPersonsList()
        {
            //return _db.spGetAllPersons().
            //    Select(temp => ConvertPersonTypeToPersonResponse(temp)).ToList();
            List<Person> persons = await _db.Persons.Include("Country").ToListAsync();
            return persons.
                Select(temp => temp.ToPersonResponse()).ToList();
        }

        /// <summary>
        /// This methods gives Person details by PersonId
        /// </summary>
        /// <param name="personId">Contails Guid of the Person</param>
        /// <returns>Return the PersonResponse</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<PersonResponse>? GetPersonDetailsByPersonId(Guid? personId)
        {
            //If person Id is Null
            if (personId == null)
                return null;

            //If User enters Valid PersonId
            Person? person = _db.spGetAllPersons().FirstOrDefault(temp => temp.PersonId == personId);

            if(person == null)
                return null;

            return person.ToPersonResponse(); 
        }

        /// <summary>
        /// Filters the persons List based on searchby and SearchName 
        /// </summary>
        /// <param name="SearchBy">Person Property name like personName, Email.....</param>
        /// <param name="SearchText">Text of the Person property to be searched</param>
        /// <returns>Filtered list of persons to be searched</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<PersonResponse>> GetFilteredPersons(string? SearchBy, string? SearchText)
        {
            List<PersonResponse> allPersons = await GetAllPersonsList();
            List<PersonResponse> matchingPersons = allPersons;

            if(string.IsNullOrEmpty(SearchBy) || string.IsNullOrEmpty(SearchText))
            {
                return matchingPersons;
            }

            switch(SearchBy)
            {
                case nameof(PersonResponse.PersonName):
                    matchingPersons = allPersons.Where(temp =>
                    (!string.IsNullOrEmpty(temp.PersonName) ?
                    temp.PersonName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PersonResponse.Email):
                    matchingPersons = allPersons.Where(temp =>
                    (!string.IsNullOrEmpty(temp.Email) ?
                    temp.Email.Contains(SearchText, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PersonResponse.DateOfBirth):
                    matchingPersons = allPersons.Where(temp =>
                    (temp.DateOfBirth != null ?
                    temp.DateOfBirth.Value.ToString("dd MMMM yyyy").Contains(SearchText, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PersonResponse.Gender):
                    matchingPersons = allPersons.Where(temp =>
                    (!string.IsNullOrEmpty(temp.Gender) ?
                    temp.Gender.Contains(SearchText) : true)).ToList();
                    break;

                case nameof(PersonResponse.CountryName):
                    matchingPersons = allPersons.Where(temp =>
                    (!string.IsNullOrEmpty(temp.CountryName) ?
                    temp.CountryName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PersonResponse.Address):
                    matchingPersons = allPersons.Where(temp =>
                    (!string.IsNullOrEmpty(temp.Address) ?
                    temp.Address.Contains(SearchText, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PersonResponse.ReceiveNewsLetters):
                    matchingPersons = allPersons.Where(temp =>
                    temp.ReceiveNewsLetters.ToString().Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;

                default: matchingPersons = allPersons; break;
            }
            return matchingPersons; 
        }

        /// <summary>
        /// Sorts Person responses either in ASC or DESC When User clicks on Properties of Person
        /// </summary>
        /// <param name="allPersons">Person Responses</param>
        /// <param name="searchBy">Search by person name, DOB, Gender....etc</param>
        /// <param name="searchOrder">ASC or DESC</param>
        /// <returns>Returns sorted order either in Ascending or Descnding order</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<PersonResponse>> GetSortedPersonsList(List<PersonResponse> allPersons, string searchBy, SortOrderOptions searchOrder)
        {
            if(string.IsNullOrEmpty(searchBy))
            {
                return allPersons;
            }

            List<PersonResponse> sortedResponseList = (searchBy, searchOrder) switch
            {
                //for person Name
                (nameof(PersonResponse.PersonName), SortOrderOptions.ASC)
                =>allPersons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.PersonName), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),
                
                //For email
                (nameof(PersonResponse.Email), SortOrderOptions.ASC)
                => allPersons.OrderBy(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Email), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

                //for country name
                (nameof(PersonResponse.CountryName), SortOrderOptions.ASC)
                => allPersons.OrderBy(temp => temp.CountryName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.CountryName), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(temp => temp.CountryName, StringComparer.OrdinalIgnoreCase).ToList(),

                //For Date of Birth
                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.ASC)
                => allPersons.OrderBy(temp => temp.DateOfBirth).ToList(),

                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(temp => temp.DateOfBirth).ToList(),

                //for Age
                (nameof(PersonResponse.Age), SortOrderOptions.ASC)
                => allPersons.OrderBy(temp => temp.Age).ToList(),

                (nameof(PersonResponse.Age), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(temp => temp.Age).ToList(),

                //for gender
                (nameof(PersonResponse.Gender), SortOrderOptions.ASC)
                => allPersons.OrderBy(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Gender), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

                //For address
                (nameof(PersonResponse.Address), SortOrderOptions.ASC)
                => allPersons.OrderBy(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Address), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                //for receiving letters
                (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.ASC)
                => allPersons.OrderBy(temp => temp.ReceiveNewsLetters).ToList(),

                (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(temp => temp.ReceiveNewsLetters).ToList(),

                _ => allPersons
            };

            return sortedResponseList;
        }

        /// <summary>
        /// Updates the selected person Detais
        /// </summary>
        /// <param name="personUpdateRequest">The person Details need to be updated</param>
        /// <returns>returns new person response obj after updating the person details</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<PersonResponse> UpdatePersonDetails(PersonUpdateRequest? personUpdateRequest)
        {
            //if personUpdateRequest is null
            if (personUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(personUpdateRequest));
            }

            //Model Validations
            ValidationHelper.ModelValidation(personUpdateRequest);

            //Fetching Matching Person and Updating
            Person? matchingPerson = _db.spGetAllPersons().FirstOrDefault(temp => temp.PersonId == personUpdateRequest.PersonId);
            if (matchingPerson == null)
            {
                throw new ArgumentException("Given Person Id doesn't exist");
            }

            matchingPerson.PersonName = personUpdateRequest.PersonName;
            matchingPerson.Email = personUpdateRequest.Email;
            matchingPerson.Gender = personUpdateRequest.Gender.ToString();
            matchingPerson.DateOfBirth = personUpdateRequest.DateOfBirth;
            matchingPerson.Address = personUpdateRequest.Address;
            matchingPerson.CountryId = personUpdateRequest.CountryId;
            matchingPerson.ReceivingNewsLetters = personUpdateRequest.ReceiveNewsLetters;

            await _db.SaveChangesAsync();
            return matchingPerson.ToPersonResponse();

        }
        /// <summary>
        /// Deletes the person details
        /// </summary>
        /// <param name="personId">PersonId of the Person</param>
        /// <returns>Return true if successfull, else false</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> DeletePerson(Guid? personId)
        {
            if(personId == null)
            {
                throw new ArgumentNullException(nameof(personId));
            }

            Person? person = _db.spGetAllPersons().FirstOrDefault(temp => temp.PersonId == personId);

            if(person == null)
                return false;

            _db.Persons.Remove(_db.spGetAllPersons().First(temp => temp.PersonId == person.PersonId));
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
