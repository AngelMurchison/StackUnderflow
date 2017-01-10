using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StackOverclone3.Startup))]
namespace StackOverclone3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
