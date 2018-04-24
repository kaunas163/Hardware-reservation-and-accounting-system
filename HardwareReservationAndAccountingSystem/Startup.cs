using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HardwareReservationAndAccountingSystem.Startup))]
namespace HardwareReservationAndAccountingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
