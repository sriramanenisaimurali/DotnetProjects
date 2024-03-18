using Entities;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using System;


namespace ServiceContracts
{
    public interface IPersonsService
    {
        Task<PersonResponse> AddPerson(PersonAddRequest? personAddRequest);
        Task<List<PersonResponse>> GetAllPersonsList();
        Task<PersonResponse?> GetPersonDetailsByPersonId(Guid? personId);
        Task<List<PersonResponse>> GetFilteredPersons(string? SearchBy, string? SearchText);
        Task<List<PersonResponse>> GetSortedPersonsList(List<PersonResponse> allPersons, string searchBy, SortOrderOptions searchOrder);
        Task<PersonResponse> UpdatePersonDetails(PersonUpdateRequest? personUpdateRequest);
        Task<bool> DeletePerson(Guid? personId);

    }
}
