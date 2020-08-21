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
            string firstName, string lastName, 
            //string skills, 
            string experience, string phoneNumber, byte[] staffPhoto, 
            string education, int salaryId, string location)
        {
            var id = Guid.NewGuid();
            var data = new 
            {
                Id = id,
                EmailAddress = emailAddress,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                //Skills = skills,
                Experience = experience,
                PhoneNumber = phoneNumber,
                StaffPhoto = staffPhoto,
                Education = education,
                Salary = salaryId,
                Location = location
            };

            //string staffSql = @"EXEC spAddStaff @Id, @EmailAddress, @Password, @FirstName, @LastName, @Skills, @Experience, @PhoneNumber";
            string staffSql = @"EXEC spAddSTaff @Id, @EmailAddress, @Password, @FirstName, @LastName, @Experience, @PhoneNumber, @Education, @Salary, @Location";
            int i =  SQLDataAccess.SaveData(staffSql, data);

            string photoSql = @"EXEC spUploadStaffPhoto @EmailAddress, @StaffPhoto";
            if (staffPhoto != null)
            {
                int i2 = SQLDataAccess.SaveData(photoSql, data);
            }

            return 1;

        }

        internal static StaffModel LoadStaff(string email)
        {
            string sql = String.Format("Exec spGetStaff '{0}'",email);
            return SQLDataAccess.LoadData<StaffModel>(sql).FirstOrDefault();
        }

        public static List<StaffModel> LoadAllStaff()
        {
            string sql = "Exec spGetAllStaff";

            return SQLDataAccess.LoadData<StaffModel>(sql);
        }

        public static byte[] LoadPhoto(string emailAddress)
        {
            string sql = String.Format("Exec spGetStaffPhoto '{0}'", emailAddress);
            return SQLDataAccess.LoadData<byte[]>(sql).FirstOrDefault();
        }

        //public static IEnumerable<string> Salaries = new List<string>
        //{
            //"$30,000 - $40,000",
            //"$40,001 - $50,000",
            //"$50,001 - $60,000",
            //"$60,001 - $70,000",
            //"$70,001 - $80,000",
            //"$80,001+"
        //};

        public static IEnumerable<Salary> Salaries()
        {
            string sql = "Exec spGetSalaries";
            return SQLDataAccess.LoadData<Salary>(sql);
        }

        internal static int SaveStaff(string emailAddress, string firstName, string lastName, string experience, string phoneNumber, byte[] staffPhoto, string education, int salaryId, string location)
        {
            var data = new
            {
                EmailAddress = emailAddress,
                FirstName = firstName,
                LastName = lastName,
                Experience = experience,
                PhoneNumber = phoneNumber,
                StaffPhoto = staffPhoto,
                Education = education,
                Salary = salaryId,
                Location = location
            };

            string staffSql = @"EXEC spUpdateStaff @EmailAddress, @FirstName, @LastName, @Experience, @PhoneNumber, @Education, @Salary, @Location";
            int i = SQLDataAccess.SaveData(staffSql, data);

            string photoSql = @"EXEC spUploadStaffPhoto @EmailAddress, @StaffPhoto";
            if (staffPhoto != null)
            {
                int i2 = SQLDataAccess.SaveData(photoSql, data);
            }

            return 1;
        }
    }
}