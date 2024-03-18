using Entities;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Receives the person details which are needed to update
    /// </summary>
    public class PersonUpdateRequest
    {
        [Required(ErrorMessage = "Person Id can't be empty")]
        public Guid PersonId { get; set; }
        [Required(ErrorMessage = "Person Name can't be empty")]
        public string? PersonName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of birth can't be empty")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Email address can't be empty")]
        [EmailAddress(ErrorMessage = "Enter valid Email Address")]
        public string? Email { get; set; }
        public GenderOptions? Gender { get; set; }
        public Guid? CountryId { get; set; }
        public string? Address { get; set; }
        public bool ReceiveNewsLetters { get; set; }

        /// <summary>
        /// This method used for converting current object to new PersonType object
        /// </summary>
        /// <returns>Person details as object</returns>
        public Person ToPerson()
        {
            return new Person()
            {
                PersonId = PersonId,
                PersonName = PersonName,
                DateOfBirth = DateOfBirth,
                Email = Email,
                Address = Address,
                Gender = Gender.ToString(),
                CountryId = CountryId,
                ReceivingNewsLetters = ReceiveNewsLetters
            };
        }
    }
}
