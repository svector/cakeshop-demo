using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Dialect;

namespace CakeShopData.Ioc
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(Component.For<ISessionFactory>().UsingFactoryMethod((kernel) =>
            {
                var config = kernel.Resolve<IConfigurationRoot>();

                return Fluently.Configure()
                    .Database(MySQLConfiguration.Standard
                        .ConnectionString(cs => cs.Server(config["DatabaseServer"]).Database("cakeshop").Username("cakeweb").Password("cakepassword")))
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .BuildSessionFactory();

            })
            .LifestyleSingleton());

            container.Register(Component.For<ISession>().UsingFactoryMethod((kernel) => kernel.Resolve<ISessionFactory>().OpenSession())
            .LifestyleScoped<MsScopedAccesor>());

            container.Register(Classes.FromThisAssembly().Pick().WithServiceAllInterfaces().LifestyleScoped<MsScopedAccesor>());
        }
    }
}
