using ServiceContracts;
using ServiceContracts.DTO;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        private readonly PersonsDbContext _db;

        public CountriesService(PersonsDbContext personsDbContext)
        {    
            _db = personsDbContext;
        }

        /// <summary>
        /// Adds the country object into List
        /// </summary>
        /// <param name="countryAddRequest"></param>
        /// <returns>Returns the Country object after adding it into list</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public async Task<CountryResponse> AddCountry(CountryAddRequest? countryAddRequest)
        {
            //When CountryAddRequest is NULL
            if(countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            //When CountryName is NULL
            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest));
            }

            //when user enters duplicate country value
            if(await _db.Countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).CountAsync() > 0)
            {
                throw new ArgumentException("Given Country already exists");
            }

            //when user enters proper country name
            Country country = countryAddRequest.ToCountry();
            country.CountryId = Guid.NewGuid();
            _db.Add(country);
            await _db.SaveChangesAsync();

            return CountryExtensions.ToCountryResponse(country);

        }
        /// <summary>
        /// Returns all countries from the list
        /// </summary>
        /// <returns>All countries from the list as the list of countryResponse</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<CountryResponse>> GetAllCountiesList()
        {
             return await _db.Countries.Select(country => CountryExtensions.ToCountryResponse(country)).ToListAsync();
        }

        /// <summary>
        /// Provides countryName by Using countryId
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns>CountryResponse by using countryId</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<CountryResponse?> GetCountryByCountryId(Guid? countryId)
        {
            if(countryId == null)
            {
                return null;
            }

            Country? countryReponseByCountryId = await _db.Countries.FirstOrDefaultAsync(temp => temp.CountryId == countryId);
            if(countryReponseByCountryId == null)
            {
                return null;
            }

            return CountryExtensions.ToCountryResponse(countryReponseByCountryId);
        }
    }
}