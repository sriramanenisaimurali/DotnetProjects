using ServiceContracts.Enums;
using System;
using Entities;


namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO class that is used to send Person Responses of PersonService class
    /// </summary>
    public class PersonResponse
    {
        public Guid PersonId { get; set; }
        public string? PersonName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Double? Age { get; set; }
        public Guid? CountryId { get; set; }
        public string? CountryName { get; set; }
        public bool ReceiveNewsLetters { get; set; }
        public string? Address { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (obj.GetType() != typeof(PersonResponse)) return false;

            PersonResponse compare_person = (PersonResponse)obj;
            return compare_person.PersonId == PersonId &&
                   compare_person.PersonName == PersonName &&
                   compare_person.Gender == Gender &&
                   compare_person.DateOfBirth == DateOfBirth &&
                   compare_person.Address == Address &&
                   compare_person.Email == Email &&
                   compare_person.ReceiveNewsLetters == ReceiveNewsLetters &&
                   compare_person.Address == Address;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Convervts current object to new PersonUpdateRequest Object
        /// </summary>
        /// <returns>Returns the new PersonUpdateRequest object</returns>
        public PersonUpdateRequest ToPersonUpdateRequest()
        {
            return new PersonUpdateRequest()
            {
                PersonId = PersonId,
                PersonName = PersonName,
                Address = Address,
                Email = Email,
                DateOfBirth = DateOfBirth,
                Gender = (GenderOptions)Enum.Parse(typeof(GenderOptions), Gender, true),
                ReceiveNewsLetters = ReceiveNewsLetters,
                CountryId = CountryId,
            };
        }
    }
    public static class PersonExtensions
    {
        /// <summary>
        /// Converts current obj into Person Response obj
        /// </summary>
        /// <param name="person">Received as argument that need to be converted</param>
        /// <returns> Returns PersonResPonse object</returns>
        public static PersonResponse ToPersonResponse(this Person person)
        {
            return new PersonResponse()
            {
                PersonId = person.PersonId,
                PersonName = person.PersonName,
                Address = person.Address,
                Gender = person.Gender,
                CountryId = person.CountryId,
                DateOfBirth = person.DateOfBirth,
                Email = person.Email,
                ReceiveNewsLetters = person.ReceivingNewsLetters,
                Age = (person.DateOfBirth != null) ? Math.Round((DateTime.Now - person.DateOfBirth.Value).TotalDays / 365.25) : null,
                CountryName = person.Country?.CountryName,
            };
        }
    }
}
