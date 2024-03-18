using Entities;
using ServiceContracts.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO class that is used for send requests for methods of personservice class
    /// </summary>
    public class PersonAddRequest
    {
        [Required(ErrorMessage = "Person Name can't be empty")]
        [MaxLength(50)]
        public string? PersonName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of birth can't be empty")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email address can't be empty")]
        [EmailAddress(ErrorMessage = "Enter valid Email Address")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Gender can't be empty")]
        public GenderOptions? Gender { get; set; }

        [Required(ErrorMessage = "Please Select the country")]
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
