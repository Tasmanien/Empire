using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Empire.Website.Startup))]
namespace Empire.Website
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{

		}
	}
}
