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
            string firstName, string lastName, string experience, string phoneNumber,
            byte[] staffPhoto, byte[] staffResume, string staffResumeFileName,
            int educationID, int salaryId, string location)
        {
            var id = Guid.NewGuid();
            var data = new 
            {
                Id = id,
                EmailAddress = emailAddress,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Experience = experience,
                PhoneNumber = phoneNumber,
                StaffPhoto = staffPhoto,
                StaffResume = staffResume,
                StaffResumeFileName = staffResumeFileName,
                Education = educationID,
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

            string resumeSql = @"EXEC spUploadStaffResume @EmailAddress, @StaffResumeFileName, @StaffResume";
            if (staffResume != null)
            {
                int i3 = SQLDataAccess.SaveData(resumeSql, data);
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

        // pull staff education id from DB
        public static IEnumerable<Salary> Salaries()
        {
            string sql = "Exec spGetSalaries";
            return SQLDataAccess.LoadData<Salary>(sql);
        }
          public static string GetSalaryById(int salaryId)
        {
            string sql = String.Format("Exec spGetSalaryById '{0}'", salaryId);
            return SQLDataAccess.LoadData<string>(sql).FirstOrDefault();

        }

        // pull staff request from 
        public static IEnumerable<Education> EducationLevels()
        {
            string sql = "Exec spGetEducation";
            return SQLDataAccess.LoadData<Education>(sql);
        }
   
        public static string GetEducationLevel(int EducationID)
        {
            string sql = String.Format("Exec spGetEducationById '{0}'", EducationID);
            return SQLDataAccess.LoadData<string>(sql).FirstOrDefault();

        }

        internal static int SaveStaff(string emailAddress, string firstName, 
            string lastName, string experience, string phoneNumber, byte[] staffPhoto, 
            byte[] staffResume, string staffResumeFileName, int education, int salaryId,
            string location)
        {
            var data = new
            {
                EmailAddress = emailAddress,
                FirstName = firstName,
                LastName = lastName,
                Experience = experience,
                PhoneNumber = phoneNumber,
                StaffPhoto = staffPhoto,
                StaffResume = staffResume,
                StaffResumeFileName = staffResumeFileName,
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

            string resumeSql = @"EXEC spUploadStaffResume @EmailAddress, @StaffResumeFileName, @StaffResume";
            if (staffResume != null)
            {
                int i2 = SQLDataAccess.SaveData(resumeSql, data);
            }

            return 1;
        }
    }
}