using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taylor_Mvc.Models;
using Taylor_Mvc.DataAccess;

namespace Taylor_Mvc.BusinessLogic
{
    public class AdminProcessor
    {
        public static List<StaffingRequestViewModel> LoadAllStaffRequests()
        {
            string sql = "Exec spLoadAllStaffRequests";
            return SQLDataAccess.LoadData<StaffingRequestViewModel>(sql);
        }

        public static void DeleteStaffingRequest(string id)
        {
            var data = new
            {
                StaffingRequestId = id
            };
            string sql = @"Exec spDeleteStaffingRequest @StaffingRequestId";

            SQLDataAccess.SaveData(sql, data);
        }

        public static void ApproveStaffingRequest(string id)
        {
            var data = new
            {
                StaffingRequestId = id
            };
            string sql = @"Exec spApproveStaffingRequest @StaffingRequestId";

            SQLDataAccess.SaveData(sql, data);
        }
    }
}