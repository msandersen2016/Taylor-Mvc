using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taylor_Mvc.BusinessLogic;
using Taylor_Mvc.Models;
using Xunit;

namespace Taylor_MVC.Tests
{
    public class AdminProcessorTests
    {
        [Fact]
        public void LoadAllStaffRequests_ShouldReturnStaffRequests()
        {
            //Arrange

            //Act
            var actual = AdminProcessor.LoadAllStaffRequests();

            //Assert
            Assert.IsType<List<StaffingRequestViewModel>>(actual);
        }

        [Fact]
        public void LoadAllStaffRequests_ShouldReturnNonZeroStaffRequests()
        {
            //Arrange

            //Act
            var actual = AdminProcessor.LoadAllStaffRequests();

            //Assert
            Assert.NotEmpty(actual);
        }
    }
}
