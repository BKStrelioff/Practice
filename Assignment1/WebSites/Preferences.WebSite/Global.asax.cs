﻿#region usings

using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Framework.Annotations;

#endregion

namespace Preferences.WebSite
{

    /// <summary>
    ///     Class WebApiApplication.
    /// </summary>
    /// <seealso cref="System.Web.HttpApplication" />
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for WebApiApplication
    public class WebApiApplication : HttpApplication
    {

        #region instance non-public methods

        /// <summary>
        ///     Applications the start.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Application_Start
        protected void Application_Start ( )
        {
            AreaRegistration.RegisterAllAreas ( );
            GlobalConfiguration.Configure ( WebApiConfig.Register );
            FilterConfig.RegisterGlobalFilters ( GlobalFilters.Filters.NotNull ( ) );
            RouteConfig.RegisterRoutes ( RouteTable.Routes.NotNull ( ) );
            BundleConfig.RegisterBundles ( BundleTable.Bundles.NotNull ( ) );
        }

        #endregion

    }

}
