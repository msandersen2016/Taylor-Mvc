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
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ShouldReturnNonNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void About_ShouldReturnNonNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Contact_ShouldReturnNonNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void RegisterStaff_ShouldReturnNonNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.RegisterStaff() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void RegisterClient_ShouldReturnNonNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.RegisterClient() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }
    }
}
