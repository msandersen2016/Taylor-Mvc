using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taylor_Mvc.BusinessLogic;
using Taylor_Mvc.Models;

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

                var allUsers = new AllUsers();
                allUsers.StaffModels = new List<StaffModel>();
                allUsers.ClientModels = new List<ClientModel>();

                allUsers.StaffModels = StaffProcessor.LoadAllStaff();
                allUsers.ClientModels = ClientProcessor.LoadAllClients();

                return View(allUsers);
            }
            else return RedirectToAction("Index", "Home");
        }
        // GET: Admin
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Delete(string id)
        {
            UserProcessor.DeleteUser(id);
            return RedirectToAction("UserManagement","Admin");
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //public ActionResult Details(string id)
        //{
        //    return RedirectToAction("Index", "Home");
        //}
    }
}