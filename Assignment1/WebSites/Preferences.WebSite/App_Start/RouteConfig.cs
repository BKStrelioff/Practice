﻿#region usings

using System.Web.Mvc;
using System.Web.Routing;

using Framework.Annotations;

#endregion

namespace Preferences.WebSite
{

    /// <summary>
    ///     Class RouteConfig.
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for RouteConfig
    public class RouteConfig
    {

        #region class public methods

        /// <summary>
        ///     Registers the routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for RegisterRoutes
        public static void RegisterRoutes ( [ NotNull ] RouteCollection routes )
        {
            routes.IgnoreRoute ( "{resource}.axd/{*pathInfo}" );

            routes.MapRoute ( "Default",
                "{controller}/{action}/{id}",
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                } );
        }

        #endregion

    }

}
