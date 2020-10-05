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
            List<ContractViewModel> contracts = AdminProcessor.LoadContracts();

            return View(contracts);
        }

        public ActionResult StaffingRequests()
        {
            List<StaffingRequestViewModel> allStaffRequests = new List<StaffingRequestViewModel>();

            allStaffRequests = AdminProcessor.LoadAllStaffRequests();

            return View(allStaffRequests);
        }

        public ActionResult DeleteStaffingRequest(string id)
        {
            AdminProcessor.DeleteStaffingRequest(id);

            TempData["StaffingRequestAction"] = "Deleted";

            return RedirectToAction("StaffingRequests", "Contracts");
        }

        public ActionResult DeleteContract(string id)
        {
            AdminProcessor.DeleteContract(id);

            TempData["ContractAction"] = "Deleted";

            return RedirectToAction("Contracts", "Contracts");
        }

        public ActionResult ApproveStaffingRequest(string id)
        {
            AdminProcessor.ApproveStaffingRequest(id);

            TempData["StaffingRequestAction"] = "Approved";

            return RedirectToAction("StaffingRequests", "Contracts");
        }

        public ActionResult SubmitStaffingRequest()
        {
            var data = StaffProcessor.LoadFreeStaff();
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
                    EducationID = staff.EducationId,
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
            if (selectedIds.Count() > 0 && selectedIds.Count() < 4)
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
                TempData["SubmitStaffSuccess"] = "invalidNumberSelected";
            }
            //TODO: process selected staff
            return RedirectToAction("SubmitStaffingRequest");
        }
    }
}