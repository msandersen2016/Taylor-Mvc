using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taylor_Mvc.Controllers
{
    [Authorize(Roles = "Admin, Contract Manager")]
    public class ContractsController : Controller
    {
        // GET: Contracts
        public ActionResult Contracts()
        {
            return View();
        }
        public ActionResult StaffingRequests()
        {
            return View();
        }
    }
}