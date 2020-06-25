using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hirmudemja.Startup))]
namespace hirmudemja
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
