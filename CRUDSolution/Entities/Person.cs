using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Entities
{
    /// <summary>
    /// Person Domain model class
    /// </summary>
    public class Person
    {
        [Key]
        public Guid PersonId { get; set; }
        [StringLength(50)]
        public string? PersonName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [StringLength(10)]
        public string? Gender { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        public Guid? CountryId { get; set; }
        public bool ReceivingNewsLetters { get; set; }
        [StringLength(100)]
        public string? Address { get; set; }
        public virtual Country? Country { get; set; }
    }
}
