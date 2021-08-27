using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiExercise.Handlers;

namespace WebApiExercise.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            string token = TokenValidationHandler.GenerateToken("Juan");

            // Assert
            Assert.IsNotNull(token);
        }
    }
}
