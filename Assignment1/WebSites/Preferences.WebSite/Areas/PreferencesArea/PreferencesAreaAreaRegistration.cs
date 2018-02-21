﻿using System.Web.Mvc;

namespace Preferences.WebSite.Areas.PreferencesArea
{
    /// <summary>
    /// Class PreferencesAreaAreaRegistration.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.AreaRegistration" />
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for PreferencesAreaAreaRegistration
    public class PreferencesAreaAreaRegistration : AreaRegistration 
    {
        /// <summary>
        /// Gets the name of the area to register.
        /// </summary>
        /// <value>The name of the area.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for AreaName
        public override string AreaName 
        {
            get 
            {
                return "PreferencesArea";
            }
        }

        /// <summary>
        /// Registers an area in an ASP.NET MVC application using the specified area's context information.
        /// </summary>
        /// <param name="context">Encapsulates the information that is required in order to register the area.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for RegisterArea
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