using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taylor_Mvc.Models
{
    public class StaffingRequestViewModel
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string firstStaff { get; set; }
        public string secondStaff { get; set; }
        public string thirdStaff { get; set; }
    }
}