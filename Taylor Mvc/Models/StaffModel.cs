using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taylor_Mvc.Models
{
    public class StaffModel : UserModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please provide your first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please provide your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide your skills")]
        public string Skills { get; set; }

        [Required(ErrorMessage = "Please provide your experience")]
        public string Experience { get; set; }

        public Guid Id { get; set; }

    }
}