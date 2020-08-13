using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taylor_Mvc.Models
{
    public class SelectStaffEditorViewModel
    {
        public bool Selected { get; set; }
        public string Email { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        public string Skills { get; set; }
        public string Experience { get; set; }
    }
}