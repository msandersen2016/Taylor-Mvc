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

        public static List<ContractViewModel> LoadContracts()
        {
            string sql = "Exec spGetContracts";
            return SQLDataAccess.LoadData<ContractViewModel>(sql);
        }

        public static void ApproveStaffingRequest(string id)
        {
            var data = new
            {
                StaffingRequestId = id
            };
            string sql = @"Exec spApproveStaffingRequestAndDeleteStaff @StaffingRequestId";

            SQLDataAccess.SaveData(sql, data);
        }

        public static void DeleteContract(string id)
        {
            var data = new
            {
                ContractId = id
            };
            string sql = @"Exec spDeleteContract @ContractId";

            SQLDataAccess.SaveData(sql, data);
        }
    }
}