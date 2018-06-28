using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EScouting.Startup))]
namespace EScouting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
