using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace EconomyManager.Api
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			//var trace = config.EnableSystemDiagnosticsTracing();
			//trace.IsVerbose = true;
			//trace.MinimumLevel = TraceLevel.Debug;

			config.EnableCors();

			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
