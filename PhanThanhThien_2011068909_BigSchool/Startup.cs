using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhanThanhThien_2011068909_BigSchool.Startup))]
namespace PhanThanhThien_2011068909_BigSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
