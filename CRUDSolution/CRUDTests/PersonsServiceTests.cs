using ServiceContracts;
using Services;
using System;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDTests
{
    public class PersonsServiceTests
    {
        //private fields
        private readonly IPersonsService _personsService;
        private readonly ICountriesService _countriesService;
        //constructor
        public PersonsServiceTests()
        {
            _countriesService = new CountriesService(
                new PersonsDbContext(new DbContextOptionsBuilder<PersonsDbContext>().Options));
            _personsService = new PersonsService(
                new PersonsDbContext(new DbContextOptionsBuilder<PersonsDbContext>().Options),_countriesService);
        }

        #region Sample Data
        //Sample data used in Unit test cases(Repetative code)
        public List<PersonResponse> SampleData()
        {
            CountryAddRequest countryAddRequest1 = new CountryAddRequest()
            {
                CountryName = "India"
            };
            CountryAddRequest countryAddRequest2 = new CountryAddRequest()
            {
                CountryName = "USA"
            };

            CountryResponse countryResponse1 = _countriesService.AddCountry(countryAddRequest1);
            CountryResponse countryResponse2 = _countriesService.AddCountry(countryAddRequest2);

            List<PersonAddRequest> personAddRequestList = new List<PersonAddRequest>()
            {
                new PersonAddRequest
                {
                    PersonName = "Person 1",
                    Email = "person1@gmail.com",
                    Address = "Person 1 Address",
                    CountryId = countryResponse1.CountryId,
                    DateOfBirth = DateTime.Parse("2002-01-01"),
                    Gender = GenderOptions.Male,
                    ReceiveNewsLetters = true
                },
                new PersonAddRequest
                {
                    PersonName = "Mary",
                    Email = "person2@gmail.com",
                    Address = "Person 2 Address",
                    CountryId = countryResponse2.CountryId,
                    DateOfBirth = DateTime.Parse("2002-02-02"),
                    Gender = GenderOptions.Female,
                    ReceiveNewsLetters = true,
                },
                new PersonAddRequest
                {
                    PersonName = "Kamal",
                    Email = "person3@gmail.com",
                    Address = "Person 3 Address",
                    CountryId = countryResponse1.CountryId,
                    DateOfBirth = DateTime.Parse("2002-03-03"),
                    Gender = GenderOptions.Others,
                    ReceiveNewsLetters = false,
                }
            };

            List<PersonResponse> personResponseList = new List<PersonResponse>();

            foreach (PersonAddRequest personAddRequest in personAddRequestList)
            {
                personResponseList.Add(_personsService.AddPerson(personAddRequest));
            }

            return personResponseList;
        }

        #endregion

        #region AddPerson
        [Fact]
        // if PersonAddRequest parameter is null;
        public void AddPerson_NullPersonAddRequest()
        {
            //Arrange
            PersonAddRequest? personAddRequest = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _personsService.AddPerson(personAddRequest);
            });
        }

        [Fact]
        //When PersonName is null in PersonAddRequest
        public void AddPerson_NullPersonName()
        {
            //Arrange
            PersonAddRequest? personName = new PersonAddRequest() { PersonName = null };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _personsService.AddPerson(personName);
            });
        }

        [Fact]
        //When User enters proper PersonAddResquest details
        public void AddPerson_ProperPersonAddRequest()
        {
            //Arrange
            PersonAddRequest personAddRequest = new PersonAddRequest()
            {
                PersonName = "John",
                Gender = GenderOptions.Male,
                DateOfBirth = DateTime.Parse("2002-02-13"),
                Email = "Sample@gmail.com",
                Address = "Sample Address",
                CountryId = Guid.NewGuid(),
                ReceiveNewsLetters = true
            };

            //Act
            PersonResponse personResponseFromAdd = _personsService.AddPerson(personAddRequest);
            List<PersonResponse> personResponseFromList = _personsService.GetAllPersonsList();

            //Assert
            Assert.True(personResponseFromAdd.PersonId != Guid.Empty);
            Assert.Contains(personResponseFromAdd, personResponseFromList);
        }

        #endregion

        #region GetPersonDetailsByPersonId

        //When Guid is null
        [Fact]
        public void GetPersonDetailsByPersonId_NullPersonId()
        {
            //Arrange
            Guid? personId = Guid.Empty;

            //Act
            PersonResponse? personResponse = _personsService.GetPersonDetailsByPersonId(personId);

            //Assert
            Assert.Null(personResponse);
        }

        //If user enters valis personId
        [Fact]
        public void GetPersonDetailsByPersonId_ValidPersonId()
        {
            //Arrange
            CountryAddRequest countryAddRequest = new CountryAddRequest()
            {
                CountryName = "India"
            };
            CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);

            PersonAddRequest personAddRequest = new PersonAddRequest() 
            { 
                PersonName = "SampleName", 
                Email = "Sample@gmail.com", 
                DateOfBirth = DateTime.Parse("2002-05-16"), 
                Address = "sample Address", 
                CountryId = countryResponse.CountryId, 
                Gender = GenderOptions.Male, 
                ReceiveNewsLetters = true 
            };

            //Act
            PersonResponse personResponse = _personsService.AddPerson(personAddRequest);
            PersonResponse? personResponseByGetPersonId = _personsService.GetPersonDetailsByPersonId(personResponse.PersonId);
            
            //Assert
            Assert.Equal(personResponse, personResponseByGetPersonId);
        }

        #endregion

        #region GetAllPersonsList
        //GetAllPersonsList() by default it should return Empty List
        [Fact]
        public void GetAllPersonsList_EmptyList()
        {
            //Act
            List<PersonResponse> personResponseList = _personsService.GetAllPersonsList();

            //Assert
            Assert.Empty(personResponseList);
        }

        //Add few persons in List, those persons should there in GetAllPersonsList()
        [Fact]
        public void GetAllPersonsResponse_AddFewPersons()
        {
            //Arrange
            CountryAddRequest countryAddRequest1 = new CountryAddRequest()
            {
                CountryName = "India"
            };
            CountryAddRequest countryAddRequest2 = new CountryAddRequest()
            {
                CountryName = "USA"
            };

            CountryResponse countryResponse1 = _countriesService.AddCountry(countryAddRequest1);
            CountryResponse countryResponse2 = _countriesService.AddCountry(countryAddRequest2);

            List<PersonAddRequest> personAddRequestList = new List<PersonAddRequest>()
            {
                new PersonAddRequest
                {
                    PersonName = "Person 1",
                    Email = "person1@gmail.com",
                    Address = "Person 1 Address",
                    CountryId = countryResponse1.CountryId,
                    DateOfBirth = DateTime.Parse("2002-01-01"),
                    Gender = GenderOptions.Male,
                    ReceiveNewsLetters = true
                },
                new PersonAddRequest
                {
                    PersonName = "Person 2",
                    Email = "person2@gmail.com",
                    Address = "Person 2 Address",
                    CountryId = countryResponse2.CountryId,
                    DateOfBirth = DateTime.Parse("2002-02-02"),
                    Gender = GenderOptions.Female,
                    ReceiveNewsLetters = true,
                },
                new PersonAddRequest
                {
                    PersonName = "Person 3",
                    Email = "person3@gmail.com",
                    Address = "Person 3 Address",
                    CountryId = countryResponse1.CountryId,
                    DateOfBirth = DateTime.Parse("2002-03-03"),
                    Gender = GenderOptions.Others,
                    ReceiveNewsLetters = false,
                }
            }; 

            List<PersonResponse> personResponseList = new List<PersonResponse>();

            foreach(PersonAddRequest personAddRequest in personAddRequestList)
            {
                personResponseList.Add(_personsService.AddPerson(personAddRequest));
            }

            //Act
            List<PersonResponse> personResponsesFromGetAllPersons = _personsService.GetAllPersonsList();

            //Assert
            foreach(PersonResponse personResponse in personResponseList)
            {
                Assert.Contains(personResponse, personResponsesFromGetAllPersons);
            }
        }

        #endregion

        #region GetFilteresPersons
        //when user enters Searchby is null and SearchText is null
        [Fact]
        public void GetFilteredPersons_NullParameters()
        {
            //Arrange
            string? SearchBy = null;
            string? SearchText = null;
            
            CountryAddRequest countryAddRequest1 = new CountryAddRequest()
            {
                CountryName = "India"
            };
            CountryAddRequest countryAddRequest2 = new CountryAddRequest()
            {
                CountryName = "USA"
            };

            CountryResponse countryResponse1 = _countriesService.AddCountry(countryAddRequest1);
            CountryResponse countryResponse2 = _countriesService.AddCountry(countryAddRequest2);

            List<PersonAddRequest> personAddRequestList = new List<PersonAddRequest>()
            {
                new PersonAddRequest
                {
                    PersonName = "Person 1",
                    Email = "person1@gmail.com",
                    Address = "Person 1 Address",
                    CountryId = countryResponse1.CountryId,
                    DateOfBirth = DateTime.Parse("2002-01-01"),
                    Gender = GenderOptions.Male,
                    ReceiveNewsLetters = true
                },
                new PersonAddRequest
                {
                    PersonName = "Person 2",
                    Email = "person2@gmail.com",
                    Address = "Person 2 Address",
                    CountryId = countryResponse2.CountryId,
                    DateOfBirth = DateTime.Parse("2002-02-02"),
                    Gender = GenderOptions.Female,
                    ReceiveNewsLetters = true,
                },
                new PersonAddRequest
                {
                    PersonName = "Person 3",
                    Email = "person3@gmail.com",
                    Address = "Person 3 Address",
                    CountryId = countryResponse1.CountryId,
                    DateOfBirth = DateTime.Parse("2002-03-03"),
                    Gender = GenderOptions.Others,
                    ReceiveNewsLetters = false,
                }
            };

            List<PersonResponse> personResponseList = new List<PersonResponse>();

            foreach (PersonAddRequest personAddRequest in personAddRequestList)
            {
                personResponseList.Add(_personsService.AddPerson(personAddRequest));
            }

            //Act
            List<PersonResponse> personResponsesFromGetFilteredPersons = _personsService.GetFilteredPersons(SearchBy, SearchText);

            //Assert
            foreach (PersonResponse personResponse in personResponseList)
            {
                Assert.Contains(personResponse, personResponsesFromGetFilteredPersons);
            }
        }

        //when user enters Searchby is PersonName and SearchText is "ma"
        [Fact]
        public void GetFilteredPersons_EmptySearchText()
        {
            //Arrange
            CountryAddRequest countryAddRequest1 = new CountryAddRequest()
            {
                CountryName = "India"
            };
            CountryAddRequest countryAddRequest2 = new CountryAddRequest()
            {
                CountryName = "USA"
            };

            CountryResponse countryResponse1 = _countriesService.AddCountry(countryAddRequest1);
            CountryResponse countryResponse2 = _countriesService.AddCountry(countryAddRequest2);

            List<PersonAddRequest> personAddRequestList = new List<PersonAddRequest>()
            {
                new PersonAddRequest
                {
                    PersonName = "Person 1",
                    Email = "person1@gmail.com",
                    Address = "Person 1 Address",
                    CountryId = countryResponse1.CountryId,
                    DateOfBirth = DateTime.Parse("2002-01-01"),
                    Gender = GenderOptions.Male,
                    ReceiveNewsLetters = true
                },
                new PersonAddRequest
                {
                    PersonName = "Mary",
                    Email = "person2@gmail.com",
                    Address = "Person 2 Address",
                    CountryId = countryResponse2.CountryId,
                    DateOfBirth = DateTime.Parse("2002-02-02"),
                    Gender = GenderOptions.Female,
                    ReceiveNewsLetters = true,
                },
                new PersonAddRequest
                {
                    PersonName = "Kamal",
                    Email = "person3@gmail.com",
                    Address = "Person 3 Address",
                    CountryId = countryResponse1.CountryId,
                    DateOfBirth = DateTime.Parse("2002-03-03"),
                    Gender = GenderOptions.Others,
                    ReceiveNewsLetters = false,
                }
            };

            List<PersonResponse> personResponseList = new List<PersonResponse>();

            foreach (PersonAddRequest personAddRequest in personAddRequestList)
            {
                personResponseList.Add(_personsService.AddPerson(personAddRequest));
            }
            List<PersonResponse> filteredList = new List<PersonResponse>();

            //Act
            List<PersonResponse> personResponsesFromGetFilteredPersons = _personsService.GetFilteredPersons(nameof(Person.PersonName), "");

            foreach (PersonResponse personResponse in personResponseList)
            {
                if (personResponse.PersonName != null && personResponse.PersonName.Contains(""))
                {
                    filteredList.Add(personResponse);
                }
            }

            //Assert
            Assert.Equal(filteredList.Count, personResponsesFromGetFilteredPersons.Count);
            foreach (PersonResponse personResponse in filteredList)
            {
                Assert.Contains(personResponse, personResponsesFromGetFilteredPersons);
            }
        }

        //when user enters Searchby is PersonName and SearchText is Empty
        [Fact]
        public void GetFilteredPersons_ProperValues()
        {
            //Arrange
            List<PersonResponse> personResponseList = SampleData();
            List<PersonResponse> filteredList = new List<PersonResponse>();

            //Act
            List<PersonResponse> personResponsesFromGetFilteredPersons = _personsService.GetFilteredPersons(nameof(Person.PersonName), "ma");

            foreach (PersonResponse personResponse in personResponseList)
            {
                if (personResponse.PersonName != null && personResponse.PersonName.Contains("ma", StringComparison.OrdinalIgnoreCase))
                {
                    filteredList.Add(personResponse);
                }
            }
            
            //Assert
            Assert.Equal(filteredList.Count, personResponsesFromGetFilteredPersons.Count);
            foreach(PersonResponse personResponse in filteredList)
            {
                Assert.Contains(personResponse, personResponsesFromGetFilteredPersons);
            }
        }

        #endregion

        #region GetSortedPersonsList

        [Fact]
        //When we sort Person Responses by PersonName in DESC
        public void GetSortedPersonsList_ByPersonName()
        {
            //Arrange
            List<PersonResponse> personResponseList = SampleData();
            List<PersonResponse> allPersons = _personsService.GetAllPersonsList();

            //Act
            List<PersonResponse> sortedResponsesList = _personsService.GetSortedPersonsList(allPersons, nameof(PersonResponse.PersonName), SortOrderOptions.DESC);
            allPersons = allPersons.OrderByDescending(temp => temp.PersonName).ToList();

            //Assert
            for(int i=0; i<allPersons.Count; i++)
            {
                Assert.Equal(allPersons[i], sortedResponsesList[i]);
            }
        }

        #endregion

        #region UpdatePersonDetails
        //If the PersonUpdateRequest is null
        [Fact]
        public void UpdatePersonDetails_NullPersonUpdateRequest()
        {
            //Arrange
            PersonUpdateRequest? personUpdateRequest = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _personsService.UpdatePersonDetails(personUpdateRequest);
            });
        }

        //If the user enters Invalid PersonId, throws argument exception
        [Fact]
        public void UpdatePersonDetails_InvalidPersonId()
        {
            //Arrange
            PersonUpdateRequest? personUpdateRequest = new PersonUpdateRequest()
            {
                PersonId = Guid.NewGuid(),
            };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _personsService.UpdatePersonDetails(personUpdateRequest);
            });
        }

        //If the updated PersonName is null, Validating PersonName 
        [Fact]
        public void UpdatePersonDetails_NullPersonName()
        {
            //Arrange
            CountryAddRequest countryAddRequest = new CountryAddRequest() { CountryName = "India" };
            CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);

            PersonAddRequest? personAddRequest = new PersonAddRequest()
            {
                PersonName = "John",
                Email = "sample@gmail.com",
                CountryId = countryResponse.CountryId,
                Address = "Sample Address",
                DateOfBirth = DateTime.Parse("2000-02-02"),
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = true,
            };
            PersonResponse personResponse = _personsService.AddPerson(personAddRequest);
            PersonUpdateRequest updateRequest = personResponse.ToPersonUpdateRequest();
            updateRequest.PersonName = null;

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                PersonResponse personResponseFromUpdate = _personsService.UpdatePersonDetails(updateRequest);
            });
        }

        //If the User updates full details 
        [Fact]
        public void UpdatePersonDetails_UpdatePersonDetails()
        {
            //Arrange
            CountryAddRequest countryAddRequest = new CountryAddRequest() { CountryName = "India" };
            CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);

            PersonAddRequest? personAddRequest = new PersonAddRequest()
            {
                PersonName = "John",
                Email = "sample@gmail.com",
                CountryId = countryResponse.CountryId,
                Address = "Sample Address",
                DateOfBirth = DateTime.Parse("2000-02-02"),
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = true,
            };
            PersonResponse personResponse = _personsService.AddPerson(personAddRequest);
            PersonUpdateRequest updateRequest = personResponse.ToPersonUpdateRequest();
            updateRequest.PersonName = "Smith";
            updateRequest.Email = "Update@gmail.com";

            //Act
            PersonResponse personResponseFromUpdate = _personsService.UpdatePersonDetails(updateRequest);
            PersonResponse? personResponseFromGet = _personsService.GetPersonDetailsByPersonId(personResponse.PersonId);

            //Assert
            Assert.Equal(personResponseFromGet, personResponseFromUpdate);
        }

        #endregion

        #region DeletePerson
        //If Person is Invalid
        [Fact]
        public void DeletePerson_InvalidPersonId()
        {
            //Act
            bool isValid = _personsService.DeletePerson(Guid.NewGuid());

            //Assert
            Assert.False(isValid);
        }

        //If Person is valid, then returns true
        [Fact]
        public void DeletePerson_ValidPersonId()
        {
            //Arrange
            CountryAddRequest countryAddRequest = new CountryAddRequest() { CountryName = "Japan" };
            CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);

            PersonAddRequest? personAddRequest = new PersonAddRequest()
            {
                PersonName = "John",
                Email = "sample@gmail.com",
                CountryId = countryResponse.CountryId,
                Address = "Sample Address",
                DateOfBirth = DateTime.Parse("2000-02-02"),
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = true,
            };
            PersonResponse personResponse = _personsService.AddPerson(personAddRequest);


            //Act
            bool isValid = _personsService.DeletePerson(personResponse.PersonId);

            //Assert
            Assert.True(isValid);
        }

        //If PersonId is Null
        [Fact]
        public void DeletePerson_NullPersonId()
        {

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                _personsService.DeletePerson(null);
            });
        }

        #endregion
    }
}
