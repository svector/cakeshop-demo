using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;

namespace CakeShopUI.Ioc
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().Pick().WithServiceSelf().WithServiceAllInterfaces().LifestyleScoped<MsScopedAccesor>());
        }
    }
}
