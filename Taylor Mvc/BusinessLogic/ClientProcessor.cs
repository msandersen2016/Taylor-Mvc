using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taylor_Mvc.DataAccess;
using Taylor_Mvc.Models;

namespace Taylor_Mvc.BusinessLogic
{
    public static class ClientProcessor
    {
        public static int CreateClient(string emailAddress, string password,
            string firstName, string lastName, string companyName,
            string phoneNumber)
        {
            var id = Guid.NewGuid();
            ClientModel data = new ClientModel
            {
                Id = id,
                EmailAddress = emailAddress,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                CompanyName = companyName,
                PhoneNumber = phoneNumber
            };

            string sql = @"EXEC spAddClient @Id, @EmailAddress, @Password, @FirstName, @LastName, @CompanyName, @PhoneNumber";

            return SQLDataAccess.SaveData(sql, data);
        }


        public static int CreateStaffingRequest(string clientEmail)
        {
            ClientModel data = new ClientModel
            {
                EmailAddress = clientEmail
            };

            string sql = @"Exec spCreateStaffingRequest @EmailAddress";

            return SQLDataAccess.SaveData(sql, data);
        }

        public static int AddStaffToStaffRequest(string staffEmail)
        {
            StaffModel data = new StaffModel
            {
                EmailAddress = staffEmail
            };

            string sql = @"Exec spAddStaffToStaffingRequest @EmailAddress";

            return SQLDataAccess.SaveData(sql, data);
        }

        public static List<ClientModel> LoadAllClients()
        {
            string sql = "Exec spGetAllClients";

            return SQLDataAccess.LoadData<ClientModel>(sql);
        }
    }
}