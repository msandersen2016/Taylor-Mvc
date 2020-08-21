using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taylor_Mvc.Models;
using Taylor_Mvc.BusinessLogic;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

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
            ViewBag.Message = "Staff Registration Page";

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterStaff([Bind(Exclude = "StaffPhoto")]StaffModel model)
        {
            if (ModelState.IsValid)
            {
                byte[] imageData = null;

                if(Request.Files.Count > 0)
                {
                    if (Request.Files["StaffPhoto"] != null)
                    {
                        HttpPostedFileBase poImgFile = Request.Files["StaffPhoto"];

                        using (var binary = new BinaryReader(poImgFile.InputStream))
                        {
                            imageData = binary.ReadBytes(poImgFile.ContentLength);
                        }
                    }
                }

                int recordsCreated = StaffProcessor.CreateStaff(model.EmailAddress,
                    model.Password, model.FirstName, model.LastName, 
                    //model.Skills,
                    model.Experience, model.PhoneNumber, imageData, 
                    model.Education, model.SalaryId, model.Location);

                Session["emailAddress"] = model.EmailAddress;
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SaveStaff([Bind(Exclude = "StaffPhoto")] StaffModel model)
        {
            //if (ModelState.IsValid)
            //{
                byte[] imageData = null;

                if (Request.Files.Count > 0)
                {
                    if (Request.Files["StaffPhoto"] != null)
                    {
                        HttpPostedFileBase poImgFile = Request.Files["StaffPhoto"];
                        if (poImgFile.ContentLength > 0)
                        { 
                            using (var binary = new BinaryReader(poImgFile.InputStream))
                            {
                                imageData = binary.ReadBytes(poImgFile.ContentLength);
                            }
                        }
                    }
                }

                int recordsCreated = StaffProcessor.SaveStaff(model.EmailAddress,
                    model.FirstName, model.LastName,
                    //model.Skills,
                    model.Experience, model.PhoneNumber, imageData,
                    model.Education, model.SalaryId, model.Location);

                Session["emailAddress"] = model.EmailAddress;
                return RedirectToAction("MyAccount","Account");
            //}

            //return View();
        }

        public ActionResult RegisterClient()
        {
            ViewBag.Message = "Client Registration Page";

            return View();
        }

        [HttpPost]
        public ActionResult RegisterClient(ClientModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = ClientProcessor.CreateClient(model.EmailAddress,
                    model.Password, model.FirstName, model.LastName, model.CompanyName,
                    model.PhoneNumber);

                Session["emailAddress"] = model.EmailAddress;
                return RedirectToAction("Index");
            }

            return View();
        }

        public FileContentResult StaffPhoto()
        {
            string emailAddress = Session["emailAddress"].ToString();
            if (emailAddress == null)
            {
                return null;
            }

            else
            {
                return new FileContentResult(StaffProcessor.LoadPhoto(emailAddress), "image/jpeg");
            }
        }
    }
}