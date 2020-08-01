using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taylor_Mvc.Models;
using Taylor_Mvc.BusinessLogic;

namespace Taylor_Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RegisterStaff()
        {
            ViewBag.Message = "Registration Page";

            return View();
        }

        [HttpPost]
        public ActionResult RegisterStaff(StaffModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = StaffProcessor.CreateStaff(model.EmailAddress,
                    model.Password, model.FirstName, model.LastName, model.Skills,
                    model.Experience, model.PhoneNumber);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}