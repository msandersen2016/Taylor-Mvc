using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taylor_Mvc.Models
{
    public class ClientModel : UserModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please provide your first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please provide your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide your company's name")]
        public string CompanyName { get; set; }

        public Guid Id { get; set; }

    }
}