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
            string sql = String.Format("Exec spCheckUserRole '{0}','{1}'", emailAddress, role);

            List<UserModel> users = new List<UserModel>();
            users = SQLDataAccess.LoadData<UserModel>(sql);

            if (users.Count == 1)
            {
                return true;
            }
            else return false;
        }

    }
}