using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taylor_Mvc.Models
{
    public class AllUsers
    {
        public List<StaffModel> StaffModels { get; set; }
        public List<ClientModel> ClientModels { get; set; }
    }
}