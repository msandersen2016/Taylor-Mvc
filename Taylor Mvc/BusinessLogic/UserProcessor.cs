using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taylor_Mvc.DataAccess;
using Taylor_Mvc.Models;

namespace Taylor_Mvc.BusinessLogic
{
    public static class UserProcessor
    {
        public static bool isValidCredentials(string emailAddress, string password)
        {
            //TODO: Implement database logic
            UserModel data = new UserModel
            {
                EmailAddress = emailAddress,
                Password = password
            };

            string sql = String.Format("Exec spGetUserByEmailPassword '{0}','{1}'", emailAddress, password);

            List<UserModel> users = new List<UserModel>();
            users = SQLDataAccess.LoadData<UserModel>(sql);

            if (users.Count == 1)
            {
                return true;
            }
            else return false;
        }

        public static bool isInRole(string emailAddress, string role)
        {
            //TODO: logic to check for role
            return false;
        }

    }
}