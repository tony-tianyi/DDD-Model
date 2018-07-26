using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMS_Model.Startup))]
namespace CMS_Model
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
