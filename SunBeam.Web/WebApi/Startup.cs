using System.Web.Http;
using Owin;

namespace SunBeam.Web.WebApi
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			HttpConfiguration config = new HttpConfiguration();
			config.MapHttpAttributeRoutes();
			config.Routes.MapHttpRoute("Example API", "api/{controller}");
		}
	}
}
