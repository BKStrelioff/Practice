﻿#region usings

using System.Web.Optimization;

using Framework.Annotations;

#endregion

namespace Preferences.WebSite
{

    /// <summary>
    ///     Class BundleConfig.
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for BundleConfig
    public class BundleConfig
    {

        #region class public methods

        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        /// <summary>
        ///     Registers the bundles.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for RegisterBundles
        public static void RegisterBundles ( [ NotNull ] BundleCollection bundles )
        {
            bundles.Add ( new ScriptBundle ( "~/bundles/jquery" ).Include ( "~/Scripts/jquery-{version}.js" ) );

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add ( new ScriptBundle ( "~/bundles/modernizr" ).Include ( "~/Scripts/modernizr-*" ) );

            bundles.Add ( new ScriptBundle ( "~/bundles/bootstrap" ).Include ( "~/Scripts/bootstrap.js", "~/Scripts/respond.js" ) );

            bundles.Add ( new StyleBundle ( "~/Content/css" ).Include ( "~/Content/bootstrap.css", "~/Content/site.css" ) );
        }

        #endregion

    }

}
