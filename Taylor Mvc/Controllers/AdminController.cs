using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taylor_Mvc.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        // GET: Admin
        public ActionResult UserManagement()
        {
            return View();
        }
        // GET: Admin
        public ActionResult Register()
        {
            return View();
        }
    }
}