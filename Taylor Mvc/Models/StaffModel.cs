using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taylor_Mvc.Models
{
    public class StaffModel
    {
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please provide an email address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [Display(Name = "Expected Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        public string Skills { get; set; }

        [Required]
        public string Experience { get; set; }
    }
}