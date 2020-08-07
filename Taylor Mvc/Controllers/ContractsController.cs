using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taylor_Mvc.BusinessLogic;
using Taylor_Mvc.Models;

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
            var data = StaffProcessor.LoadStaff();

            List<StaffModel> staff = new List<StaffModel>();

            foreach (var sm in data)
            {
                staff.Add(new StaffModel
                {
                    EmailAddress = sm.EmailAddress,
                    ConfirmEmail = sm.EmailAddress,
                    PhoneNumber = sm.PhoneNumber,
                    FirstName = sm.FirstName,
                    LastName = sm.LastName,
                    Skills = sm.Skills,
                    Experience = sm.Experience                    
                });
            }
            return View(staff);
        }
    }
}