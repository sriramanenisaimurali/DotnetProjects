using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ControllersExample.CustomValidators;

namespace ControllersExample.Models
{
    public class Person
    {
        /*public Guid Id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public int age { get; set; }*/
        [Required(ErrorMessage = "Person Name can't be empty")]
        [RegularExpression("^[a-zA-Z\\s.]+$")]
        public string? PersonName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }
        [Phone(ErrorMessage = "Enter valid Phone Number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Enter 10 digit phone number")]
        public string? PhoneNumber { get; set; }
        //[MinAgeRequired(1925, ErrorMessage = "Year should be grater than {0}")]
        //[Required(ErrorMessage = "Date Of Birth is Required")]
        [MinAgeRequired(1925)]
        public DateTime? DateOfBirth { get; set; }
        public Double? Price { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        [DisplayName("From Date")]
        public DateTime? FromDate { get; set; }
        [Required(ErrorMessage ="{0} is Required")]
        [DisplayName("To Date")]
        [DateRangeValidator("FromDate", ErrorMessage = "Enter Valid FROM DATE and TO DATE")]
        public DateTime? ToDate { get; set; }

        public override string ToString()
        {
            return $"Person Name : {PersonName}\nEmail-Id : {Email}\nPassword : {Password}\nRegistration Status : Eligible\nPhone Number : {PhoneNumber}\nPrice : {Price}";
        }
    }
}
