using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MonsterMaker.Startup))]
namespace MonsterMaker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
