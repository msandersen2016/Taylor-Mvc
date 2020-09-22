using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taylor_Mvc.BusinessLogic;
using Taylor_Mvc.Models;

namespace Taylor_Mvc.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult MyAccount()
        {
            if (UserProcessor.IsInRole(Session["emailAddress"].ToString(), "Staff"))
            {
                StaffModel staff = StaffProcessor.LoadStaff(Session["emailAddress"].ToString());
                return View(staff);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string emailAddress, string password)
        {
            if (UserProcessor.isValidCredentials(emailAddress, password))
            {
                TempData["Action"] = "Log On";
                Session["emailAddress"] = emailAddress;
                if (UserProcessor.IsInRole(emailAddress, "Staff"))
                {
                    //TODO:redirect to staff page
                    return RedirectToAction("Index", "Home");
                }
                else if (UserProcessor.IsInRole(emailAddress, "Client"))
                {
                    //TODO:redirect to client page
                    return RedirectToAction("Index", "Home");
                }
                else if (UserProcessor.IsInRole(emailAddress, "Admin"))
                {
                    //TODO:redirect to admin page
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["Action"] = "Bad Credentials";
            }
            return View();
        }

        public ActionResult LogOff()
        {
            Session["emailAddress"] = null;
            TempData["Action"] = "Log Off";
            return RedirectToAction("Index", "Home");
        }
    }
}