using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GamePool2016.Startup))]
namespace GamePool2016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
