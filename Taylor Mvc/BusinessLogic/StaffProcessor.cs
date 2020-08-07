using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taylor_Mvc.DataAccess;
using Taylor_Mvc.Models;

namespace Taylor_Mvc.BusinessLogic
{
    public static class StaffProcessor
    {
        public static int CreateStaff(string emailAddress, string password, 
            string firstName, string lastName, string skills, string experience,
            string phoneNumber)
        {
            var id = Guid.NewGuid();
            StaffModel data = new StaffModel
            {
                Id = id,
                EmailAddress = emailAddress,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Skills = skills,
                Experience = experience,
                PhoneNumber = phoneNumber
            };

            string sql = @"EXEC spAddStaff @Id, @EmailAddress, @Password, @FirstName, @LastName, @Skills, @Experience, @PhoneNumber";

            return SQLDataAccess.SaveData(sql, data);

        }

        public static List<StaffModel> LoadStaff()
        {
            string sql = "Exec spGetAllStaff";

            return SQLDataAccess.LoadData<StaffModel>(sql);
        }

    }
}