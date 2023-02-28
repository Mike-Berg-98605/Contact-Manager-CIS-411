using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace ContactManager.Models
{
    public class ContactInfo
    {
        // EF Core will configure the database to generate this value
        public int ContactInfoID { get; set; }        

        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number must be valid.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter an email.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email must be valid.")]
        public  string Email { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a category.")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public string Organization { get; set; }
        
        public DateTime CreateDate { get; set; }

        public string Slug =>
            FirstName?.Replace(' ', '-').ToLower() + '-' + LastName?.Replace(' ', '-').ToLower();
    }
}
