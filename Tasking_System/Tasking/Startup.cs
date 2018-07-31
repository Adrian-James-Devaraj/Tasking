using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tasking.Startup))]
namespace Tasking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
