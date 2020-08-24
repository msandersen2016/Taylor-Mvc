using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
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

        //[Required(ErrorMessage = "Please provide your skills")]
        //public string Skills { get; set; }

        [Required(ErrorMessage = "Please provide your experience")]
        public string Experience { get; set; }

        [Display(Name ="Salary Range")]
        [Required(ErrorMessage = "Please provide your salary range")]
        public int SalaryId { get; set; }

        [Required(ErrorMessage = "Please provide your location")]
        public string Location { get; set; }

        [Display(Name ="Education Level")]
        [Required(ErrorMessage = "Please provide your level of education")]
        public int EducationID { get; set; }

        [Display(Name = "Photo")]
        public byte[] StaffPhoto { get; set; }

        [Display(Name = "Resume")]
        public byte[] StaffResume { get; set; }

        public Guid Id { get; set; }

    }

    public class Salary
    {
        public int SalaryId { get; set; }
        public string SalaryRange { get; set; }
    }
    public class Education
    {
        public int EducationID { get; set; }
        public string EducationLevel { get; set; }

    }
}