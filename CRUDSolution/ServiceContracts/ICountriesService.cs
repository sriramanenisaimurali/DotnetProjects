using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface ICountriesService
    {
        Task<CountryResponse> AddCountry(CountryAddRequest? countryAddRequest);

        Task<List<CountryResponse>> GetAllCountiesList();

        Task<CountryResponse?> GetCountryByCountryId(Guid? countryId);
    }
}