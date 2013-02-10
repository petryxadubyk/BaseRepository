using System.Reflection;

using Autofac;
using Autofac.Integration.WebApi;
using DataAccess.Infrastructure;
using DataAccess.Repositories;
using System.Web.Http;


namespace KitchenRecipesWebApi
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterType<DefaultCommandBus>().As<ICommandBus>().InstancePerApiRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerApiRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerApiRequest();

            builder.RegisterAssemblyTypes(typeof(DeliveryRepository)
                .Assembly).Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerApiRequest();

            /*var services = Assembly.Load("EFMVC.Domain");
            builder.RegisterAssemblyTypes(services)
            .AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerApiRequest();
            builder.RegisterAssemblyTypes(services)
            .AsClosedTypesOf(typeof(IValidationHandler<>)).InstancePerApiRequest();*/
            
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);

            var configuration = GlobalConfiguration.Configuration;
            configuration.DependencyResolver = resolver;
        }        
    }
}