using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StackOF_Clone.Startup))]
namespace StackOF_Clone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
