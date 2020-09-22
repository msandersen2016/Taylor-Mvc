using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taylor_Mvc.BusinessLogic;
using Xunit;

namespace Taylor_MVC.Tests
{
    public class UserProcessorTests
    {

        [Fact]
        public void isValidCredentials_ShouldReturnTrue()
        {
            //Arrange
            bool actual;
            string username = "kmiller.client@abms.org";
            string password = "Pr0gre$$11";

            //Act
            actual = UserProcessor.isValidCredentials(username, password);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void isValidCredentials_ShouldReturnFalse()
        {
            //Arrange
            bool actual;
            string username = "kmiller.client@abms.org";
            string password = "badPassword";

            //Act
            actual = UserProcessor.isValidCredentials(username, password);

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void isInRole_ShouldReturnTrueForClient()
        {
            //Arrange
            bool actual;
            string username = "kmiller.client@abms.org";
            string role = "Client";

            //Act
            actual = UserProcessor.IsInRole(username, role);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void isInRole_ShouldReturnFalseForClient_NonUser()
        {
            //Arrange
            bool actual;
            string username = "kmiller.notAnActualUser@abms.org";
            string role = "Client";

            //Act
            actual = UserProcessor.IsInRole(username, role);

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void isInRole_ShouldReturnFalseForClient_UserInDifferentRole()
        {
            //Arrange
            bool actual;
            string username = "kmiller.staff@abms.org";
            string role = "Client";

            //Act
            actual = UserProcessor.IsInRole(username, role);

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void isInRole_ShouldReturnTrueForStaff()
        {
            //Arrange
            bool actual;
            string username = "kmiller.staff@abms.org";
            string role = "Staff";

            //Act
            actual = UserProcessor.IsInRole(username, role);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void isInRole_ShouldReturnFalseForStaff_NonUser()
        {
            //Arrange
            bool actual;
            string username = "kmiller.notAnActualUser@abms.org";
            string role = "Staff";

            //Act
            actual = UserProcessor.IsInRole(username, role);

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void isInRole_ShouldReturnFalseForStaff_UserInDifferentRole()
        {
            //Arrange
            bool actual;
            string username = "kmiller.client@abms.org";
            string role = "Staff";

            //Act
            actual = UserProcessor.IsInRole(username, role);

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void isInRole_ShouldReturnTrueForContractManager()
        {
            //Arrange
            bool actual;
            string username = "professor_admin@gmail.com";
            string role = "Admin";

            //Act
            actual = UserProcessor.IsInRole(username, role);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void isInRole_ShouldReturnFalseForContractManager_NonUser()
        {
            //Arrange
            bool actual;
            string username = "kmiller.notAnActualUser@abms.org";
            string role = "Admin";

            //Act
            actual = UserProcessor.IsInRole(username, role);

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void isInRole_ShouldReturnFalseForContractManager_UserInDifferentRole()
        {
            //Arrange
            bool actual;
            string username = "kmiller.staff@abms.org";
            string role = "Admin";

            //Act
            actual = UserProcessor.IsInRole(username, role);

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void emailExistsShouldReturnTrue()
        {
            //Arrange
            bool actual;
            string username = "kmiller.staff@abms.org";

            //Act
            actual = UserProcessor.emailExists(username);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void emailExistsShouldReturnFalse()
        {
            //Arrange
            bool actual;
            string username = "kmiller.staff44@abms.org";

            //Act
            actual = UserProcessor.emailExists(username);

            //Assert
            Assert.False(actual);
        }

    }
}
