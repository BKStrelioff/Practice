#region usings

using System.Web.Mvc;

#endregion

#pragma warning disable 1591
namespace Preferences.WebSite.Controllers
{

    public class HomeController : Controller
    {

        #region instance public methods

        public ActionResult Index ( )
        {
            ViewBag.Title = "Home Page";

            return View ( );
        }

        #endregion

    }

}
