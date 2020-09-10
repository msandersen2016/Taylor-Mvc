using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Taylor_Mvc;
using Taylor_Mvc.Controllers;
using Xunit;

namespace Taylor_MVC.Tests
{
    public class AdminControllerTests
    {
        [Fact]
        public void UserManagement_ShouldNotReturnNull()
        {
            //Arrange
            AdminController controller = new AdminController();

            //Act
            ViewResult result = controller.UserManagement() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }
    }
}
