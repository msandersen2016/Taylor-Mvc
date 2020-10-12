using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Taylor_Mvc.Controllers;
using Xunit;

namespace Taylor_MVC.Tests
{
    public class ContractsControllerTests
    {
        [Fact]
        public void Contracts_ShouldNotReturnNull()
        {
            //Arrange
            Mock<HttpSessionStateBase> session = new Mock<HttpSessionStateBase>();
            session.SetupGet(s => s["emailAddress"]).Returns("professor_admin@gmail.com");

            Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(c => c.Session).Returns(session.Object);

            ControllerContext ctx = new ControllerContext();
            ctx.HttpContext = httpContext.Object;

            ContractsController controller = new ContractsController();
            controller.ControllerContext = ctx;

            //Act
            ViewResult result = controller.Contracts() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }
    }
}
