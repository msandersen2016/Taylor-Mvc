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
        public ActionResult RegisterStaff([Bind(Exclude = "StaffPhoto,StaffResume")]StaffModel model)
        {
            if(UserProcessor.emailExists(model.EmailAddress))
            {
                TempData["emailExists"] = "true";
                return View();
            }

            string staffResumeFileName = null;
            if (ModelState.IsValid)
            {
                byte[] photoImageData = null;
                byte[] resumeImageData = null;

                if (Request.Files.Count > 0)
                {
                    if (Request.Files["StaffPhoto"] != null)
                    {
                        HttpPostedFileBase poImgFile = Request.Files["StaffPhoto"];

                        using (var binary = new BinaryReader(poImgFile.InputStream))
                        {
                            photoImageData = binary.ReadBytes(poImgFile.ContentLength);
                        }
                    }
                    if (Request.Files["StaffResume"] != null)
                    {
                        HttpPostedFileBase poResFile = Request.Files["StaffResume"];
                        staffResumeFileName = Request.Files["StaffResume"].FileName;

                        using (var binary = new BinaryReader(poResFile.InputStream))
                        {
                            resumeImageData = binary.ReadBytes(poResFile.ContentLength);
                        }
                    }
                }

                int recordsCreated = StaffProcessor.CreateStaff(model.EmailAddress,
                    model.Password, model.FirstName, model.LastName, model.Experience, 
                    model.PhoneNumber, photoImageData, resumeImageData,staffResumeFileName, 
                    model.EducationId, model.SalaryId, model.Location);

                Session["emailAddress"] = model.EmailAddress;
                TempData["Action"] = "User Created";
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SaveStaff([Bind(Exclude = "StaffPhoto,StaffResume")] StaffModel model)
        {
            //if (ModelState.IsValid)
            //{
            byte[] photoImageData = null;
            byte[] resumeImageData = null;
            string staffResumeFileName = null;

            if (Request.Files.Count > 0)
            {
                if (Request.Files["StaffPhoto"] != null)
                {
                    HttpPostedFileBase poImgFile = Request.Files["StaffPhoto"];
                    if (poImgFile.ContentLength > 0)
                    {
                        using (var binary = new BinaryReader(poImgFile.InputStream))
                        {
                            photoImageData = binary.ReadBytes(poImgFile.ContentLength);
                        }
                    }
                }
                if (Request.Files["StaffResume"] != null)
                {
                    HttpPostedFileBase poResFile = Request.Files["StaffResume"];
                    if (poResFile.ContentLength > 0)
                    {
                        using (var binary = new BinaryReader(poResFile.InputStream))
                        {
                            resumeImageData = binary.ReadBytes(poResFile.ContentLength);
                        }
                        staffResumeFileName = Request.Files["StaffResume"].FileName;
                    }
                }
            }

            int recordsCreated = StaffProcessor.SaveStaff(model.EmailAddress,
                model.FirstName, model.LastName, model.Experience, model.PhoneNumber,
                photoImageData, resumeImageData, staffResumeFileName, model.EducationId,
                model.SalaryId, model.Location);

            Session["emailAddress"] = model.EmailAddress;
            TempData["Action"] = "Account Saved";

            return RedirectToAction("MyAccount", "Account");

        }

        public ActionResult RegisterClient()
        {
            ViewBag.Message = "Client Registration Page";

            return View();
        }

        [HttpPost]
        public ActionResult RegisterClient(ClientModel model)
        {
            if (UserProcessor.emailExists(model.EmailAddress))
            {
                TempData["emailExists"] = "true";
                return View();
            }

            if (ModelState.IsValid)
            {
                int recordsCreated = ClientProcessor.CreateClient(model.EmailAddress,
                    model.Password, model.FirstName, model.LastName, model.CompanyName,
                    model.PhoneNumber);

                Session["emailAddress"] = model.EmailAddress;
                TempData["Action"] = "User Created";
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
                try
                {
                    FileContentResult fcr = new FileContentResult(StaffProcessor.LoadPhoto(emailAddress), "image/jpeg");
                    return fcr;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}