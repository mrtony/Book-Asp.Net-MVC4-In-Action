using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CH07_Ajax.Startup))]
namespace CH07_Ajax
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
