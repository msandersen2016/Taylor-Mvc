using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taylor_Mvc.BusinessLogic;

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
            if (UserProcessor.IsInRole(Session["emailAddress"]?.ToString(), "Admin"))
            {
                return View();
            }
            else return RedirectToAction("Index", "Home");
        }
        // GET: Admin
        public ActionResult Register()
        {
            return View();
        }
    }
}