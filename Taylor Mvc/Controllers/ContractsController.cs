using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taylor_Mvc.Controllers
{
    public class ContractsController : Controller
    {
        // GET: Contracts
        public ActionResult Contracts()
        {
            return View();
        }
        // GET: Contracts
        public ActionResult StaffingRequests()
        {
            return View();
        }
    }
}