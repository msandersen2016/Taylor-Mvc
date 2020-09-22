using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Taylor_Mvc.BusinessLogic;
using Taylor_Mvc.Models;

namespace Taylor_MVC.Tests
{
    public class ClientProcessorTests
    {
        [Fact]
        public void LoadAllClients_ShouldReturnListofClients()
        {
            //Arrange

            //Act
            var actual = ClientProcessor.LoadAllClients();
            //Assert
            Assert.IsType<List<ClientModel>>(actual);
        }

        [Fact]
        public void LoadAllClients_ShouldReturnNonZeroClients()
        {
            //Arrange

            //Act
            var actual = ClientProcessor.LoadAllClients();
            //Assert
            Assert.NotEmpty(actual);
        }
    }
}