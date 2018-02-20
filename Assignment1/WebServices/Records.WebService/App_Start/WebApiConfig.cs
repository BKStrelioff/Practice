#region usings

using System.Web.Http;

#endregion

namespace Records.WebService
{

    public static class WebApiConfig
    {

        #region class public methods

        public static void Register ( HttpConfiguration config )
        {
            config.MapHttpAttributeRoutes ( );

            config.Routes.MapHttpRoute ( "DefaultApi",
                "{controller}",
                new
                {
                    id = RouteParameter.Optional
                } );
        }

        #endregion

    }

}
