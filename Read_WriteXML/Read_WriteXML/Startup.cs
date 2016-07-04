using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Read_WriteXML.Startup))]
namespace Read_WriteXML
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
