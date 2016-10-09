using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Empire.API.Startup))]

namespace Empire.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
