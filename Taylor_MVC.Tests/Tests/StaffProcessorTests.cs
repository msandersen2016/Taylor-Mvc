using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taylor_Mvc.BusinessLogic;
using Taylor_Mvc.Models;
using Xunit;

namespace Taylor_MVC.Tests
{
    public class StaffProcessorTests
    {
        [Fact]
        public void LoadAllStaff_ShouldReturnListofStaff()
        {
            //Arrange

            //Act
            var actual = StaffProcessor.LoadAllStaff();
            //Assert
            Assert.IsType<List<StaffModel>>(actual);
        }

        [Fact]
        public void LoadAllStaff_ShouldReturnNonZeroStaff()
        {
            //Arrange

            //Act
            var actual = StaffProcessor.LoadAllStaff();
            //Assert
            Assert.NotEmpty(actual);
        }

        [Fact]
        public void LoadStaff_ShouldReturnStaffObject()
        {
            //Arrange
            string email = "kmiller.staff@abms.org";
            //Act
            var actual = StaffProcessor.LoadStaff(email);
            //Assert
            Assert.IsType<StaffModel>(actual);
            Assert.Equal(actual.EmailAddress, email);
        }

        [Fact]
        public void LoadStaff_ShouldNotReturnStaffObject()
        {
            //Arrange
            string email = "kmiller.staff44@abms.org";
            //Act
            var actual = StaffProcessor.LoadStaff(email);
            //Assert
            Assert.Null(actual);
        }

    }
}
