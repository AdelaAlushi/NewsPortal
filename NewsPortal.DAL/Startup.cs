using Microsoft.Owin;
using Owin;

//[assembly: OwinStartup(typeof(NewsPortal.DAL.StartupOwin))]
[assembly: OwinStartupAttribute("NewsPortalDALConfig", typeof(NewsPortal.DAL.StartupOwin))]
namespace NewsPortal.DAL
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
