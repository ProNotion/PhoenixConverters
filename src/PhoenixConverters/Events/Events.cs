using System.Web.Http;
using System.Web.Routing;
using Umbraco.Core;

namespace PhoenixConverters.Events
{
    public class Events
    {
        public class ApplicationStartUp : ApplicationEventHandler
        {
	        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
	        {
		        base.ApplicationStarting(umbracoApplication, applicationContext);

				GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
				MapWebApiRoutes();
			}

            private void MapWebApiRoutes()
            {
                RouteTable.Routes.MapHttpRoute("PhoenixApiSourceDataTypes", "umbraco/backoffice/PhoenixApi/DataType/{action}/",
                       new
                       {
                           controller = "PhoenixApi"
                       }
                );
                RouteTable.Routes.MapHttpRoute("PhoenixApi", "umbraco/backoffice/PhoenixApi/{action}/{alias}",
                        new
                        {
                            controller = "PhoenixApi"
                        }
                );
                RouteTable.Routes.MapHttpRoute("PhoenixApiTest", "umbraco/backoffice/PhoenixApi/Perform/{action}/{alias}/{sourceDataTypeId}/{targetDataTypeId}",
                        new
                        {
                            controller = "PhoenixApi"
                        }
                );
                RouteTable.Routes.MapHttpRoute("PhoenixApiDataTypeByAlias", "umbraco/backoffice/PhoenixApi/DataType/{action}/{dataTypeAlias}",
                        new
                        {
                            controller = "PhoenixApi"
                        }
                );
            }
        }
    }
}
