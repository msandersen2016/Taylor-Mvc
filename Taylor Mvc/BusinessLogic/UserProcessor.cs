using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

        public static bool IsInRole(string emailAddress, string role)
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

        public static int DeleteUser (string UserId)
        {
            var data = new
            {
                Id = UserId
            };
            string sql = @"Exec spDeleteUser @Id";

            return SQLDataAccess.SaveData(sql, data);

        }

        public static bool emailExists (string emailAddress)
        {
            string sql = String.Format("Exec spCheckIfEmailExists '{0}'",emailAddress);

            List<string> existingEmails = SQLDataAccess.LoadData<string>(sql);
            if (existingEmails.Count > 0)
                return true;
            else
                return false;
        }

    }
}