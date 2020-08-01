using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Taylor_Mvc.BusinessLogic;

namespace Taylor_Mvc.Models
{
    public class UserModel
    {
        //[Display(Name = "First Name")]
        //[Required(ErrorMessage = "Please provide your first name")]
        //public string FirstName { get; set; }

        //[Display(Name = "Last Name")]
        //[Required(ErrorMessage = "Please provide your last name")]
        //public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please provide your email address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Confirm Email")]
        [Compare("EmailAddress", ErrorMessage = "Does not match email address.")]
        public string ConfirmEmail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please provide a password")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Your password must be between 10 and 100 characters")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Does not match password.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please provide your phone number")]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessage = "Please provide your skills")]
        //public string Skills { get; set; }

        //[Required(ErrorMessage = "Please provide your experience")]
        //public string Experience { get; set; }

        public bool isInRole(string Role)
        {
            return UserProcessor.isInRole(EmailAddress, Role);
        }
    }
}