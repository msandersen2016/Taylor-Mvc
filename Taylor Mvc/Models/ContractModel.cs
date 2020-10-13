using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taylor_Mvc.Models
{
    public class ContractModel
    {
        [Display(Name = "Contract No.")]
        public int ContractId { get; set; }

        [Display(Name = "Company")]
        public string Client { get; set; }

        public string Staff { get; set; }

        [Display(Name = "Contract Start Date")]
        public string StartDate { get; set; }

        [Display(Name = "Contract End Date")]
        public string EndDate { get; set; }
    }
}