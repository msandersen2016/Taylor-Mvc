using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taylor_Mvc.Models
{
    public class ContractViewModel
    {

        public int ContractId { get; set; }

        public string Client { get; set; }

        public string Staff { get; set; }

        [Display(Name = "Salary")]
        public string SalaryRange { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

    }
}