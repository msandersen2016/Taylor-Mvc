using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taylor_Mvc.BusinessLogic;

namespace Taylor_Mvc.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string emailAddress, string password)
        {
            if (UserProcessor.isValidCredentials(emailAddress, password))
            {
                Session["emailAddress"] = emailAddress;
                if (UserProcessor.isInRole(emailAddress, "Staff"))
                {
                    //TODO:redirect to staff page
                    RedirectToAction("Index", "Home");
                }
                else if (UserProcessor.isInRole(emailAddress, "Client"))
                {
                    //TODO:redirect to client page
                    RedirectToAction("Index", "Home");
                }
                else if (UserProcessor.isInRole(emailAddress, "Admin"))
                {
                    //TODO:redirect to admin page
                    RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}