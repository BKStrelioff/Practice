using System.Web.Mvc;

namespace Preferences.WebSite.Areas.PreferencesArea
{
    public class PreferencesAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PreferencesArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PreferencesArea_default",
                "PreferencesArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}