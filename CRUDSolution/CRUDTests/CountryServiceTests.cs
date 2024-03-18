using System;
using System.Collections.Generic;
using ServiceContracts;
using ServiceContracts.DTO;
using Entities;
using Services;
using Microsoft.EntityFrameworkCore;

namespace CRUDTests
{
    public class CountryServiceTests
    {
        private readonly ICountriesService _countriesService;
        public CountryServiceTests()
        {
            _countriesService = new CountriesService(
                new PersonsDbContext(new DbContextOptionsBuilder<PersonsDbContext>().Options));
        }

        #region AddCountry
        //Check CountryAddRequest object is null,
        //When CountryAddrequest is null it should throw ArgumentNullException
        [Fact]
        public void AddCountry_NullCountryAddRequest()
        {
            //Arrange
            CountryAddRequest? countryAddRequest = null;
            
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _countriesService.AddCountry(countryAddRequest);
            });
        }

        //Check CountryName in CountryAddRequest object is Null,
        //when CountryName is Null throw ArgumentException

        [Fact]
        public void AddCountry_NullCountryName()
        {
            //Arrange
            CountryAddRequest? countryAddRequest = new CountryAddRequest()
            { CountryName = null };
            

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countriesService.AddCountry(countryAddRequest);
            });
        }

        //Check Country already exits in list or data source,
        //when CountryName is Null throw ArgumentException
        [Fact]
        public void AddCountry_DuplicateCountryName()
        {
            //Arrange
            CountryAddRequest? countryAddRequest1 = new CountryAddRequest()
            { CountryName = "India" };
            CountryAddRequest? countryAddRequest2 = new CountryAddRequest()
            { CountryName = "India" };


            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countriesService.AddCountry(countryAddRequest1);
                _countriesService.AddCountry(countryAddRequest2);
            });
        }


        //Adding country in list, When user enter proper contry
        //it should insert the country into existing list
        [Fact]
        public void AddCountry_PerfectCountryName()
        {
            //Arrange
            CountryAddRequest? countryAddRequest = new CountryAddRequest()
            { CountryName = "USA" };

            //Act
            CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);
            List<CountryResponse> countries_list = _countriesService.GetAllCountiesList();

            //Assert
            Assert.True(countryResponse.CountryId != Guid.Empty);
            Assert.Contains(countryResponse, countries_list);
        }
        #endregion

        #region GetAllCountriesList
        [Fact]
        //List of countries should be empty by Default
        public void GetAllCountriesList_EmptyList()
        {
            //Arrange, Act
            List<CountryResponse> countriesList = _countriesService.GetAllCountiesList();

            //Assert
            Assert.Empty(countriesList);
        }

        [Fact]
        //Contains added countries in the List
        public void GetCountriesList_AddFewCountries()
        {
            //Arrange
            List<CountryAddRequest> countryAddRequest = new List<CountryAddRequest>()
            {
                new CountryAddRequest{CountryName = "India"},
                new CountryAddRequest{CountryName = "USA"}
            };

            //Act
            List<CountryResponse> coutries_response_from_AddCountry = new List<CountryResponse>();
            foreach(CountryAddRequest countryRequest in countryAddRequest)
            {
                coutries_response_from_AddCountry.Add(_countriesService.AddCountry(countryRequest));
            }

            List<CountryResponse> countriesList= _countriesService.GetAllCountiesList();

            //Assert
            foreach(CountryResponse ExpectedValue in coutries_response_from_AddCountry)
            {
                Assert.Contains(ExpectedValue, countriesList);
            }
        }

        #endregion

        #region GetCountryByCountryId
        [Fact]
        ///CountryResponse using Null CountryId
        public void GetCountryByCountryId_NullCountryId()
        {
            //Arrange
            Guid? countryId = null;

            //Act
            CountryResponse? country_response = _countriesService.GetCountryByCountryId(countryId);

            //Assert
            Assert.Null(country_response);
        }

        //CountryResponse using valid countryId
        [Fact]
        public void GetCountryByCountryId_ValidCountryId()
        {
            //Arrange
            CountryAddRequest country_add_request = new CountryAddRequest()
            {
                CountryName = "India"
            };
            CountryResponse response_from_addcountry = _countriesService.AddCountry(country_add_request);

            //Act
            CountryResponse? response_from_GetcountryByCountryId = _countriesService.GetCountryByCountryId(response_from_addcountry.CountryId);

            //Assert
            Assert.Equal(response_from_addcountry, response_from_GetcountryByCountryId);
        }

        #endregion

    }

}
