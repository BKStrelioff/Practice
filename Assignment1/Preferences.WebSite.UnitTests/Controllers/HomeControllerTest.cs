using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Preferences.WebSite;
using Preferences.WebSite.Controllers;

namespace Preferences.WebSite.UnitTests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
