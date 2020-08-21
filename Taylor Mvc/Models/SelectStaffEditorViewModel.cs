using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Taylor_Mvc.BusinessLogic;

namespace Taylor_Mvc.Models
{
    public class SelectStaffEditorViewModel
    {
        public bool Selected { get; set; }
        public string Email { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        //public string Skills { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public int SalaryId { get; set; }
        public string SalaryString { get { return StaffProcessor.GetSalaryById(SalaryId); } }
        public string Location { get; set; }
    }
}