using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
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
       
        public ActionResult SubmitStaffingRequest()
        {
            var data = StaffProcessor.LoadAllStaff();
            var allStaff = new AllStaffSelectionViewModel();
            foreach (var staff in data)
            {
                var staffView = new SelectStaffEditorViewModel()
                {
                    //Id = 2,
                    Email = staff.EmailAddress,
                    Name = string.Format("{0} {1}", staff.FirstName, staff.LastName),
                    Selected = false,
                    //Skills = staff.Skills,
                    Experience = staff.Experience,
                    Education = staff.Education,
                    SalaryId = staff.SalaryId,
                    Location = staff.Location
                };
                allStaff.Staff.Add(staffView);
            }

            return View(allStaff);
        }
        [HttpPost]
        public ActionResult SubmitStaffingRequest(AllStaffSelectionViewModel model)
        {
            // get the ids of the items selected:
            var selectedIds = model.GetSelectedIds();
            if (selectedIds.Count() > 0)
            {
                try
                {
                    ClientProcessor.CreateStaffingRequest(Session["emailAddress"].ToString());

                    foreach (string email in selectedIds)
                    {
                        ClientProcessor.AddStaffToStaffRequest(email);
                    }

                    TempData["SubmitStaffSuccess"] = "success";
                }
                catch (Exception e)
                {
                    TempData["SubmitStaffSuccess"] = "failure";
                }
            }
            else
            {
                TempData["SubmitStaffSuccess"] = "noneSelected";
            }
            //TODO: process selected staff
            return RedirectToAction("SubmitStaffingRequest");
        }
    }
}