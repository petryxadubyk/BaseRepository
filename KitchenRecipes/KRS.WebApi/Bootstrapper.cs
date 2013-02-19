using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;
using KRS.DataAccess.Contracts.UnitOfWork;
using KRS.DataAccess.IInfrastructure;
using KRS.DataAccess.Infrastructure;
using KRS.DataAccess.Repositories;

namespace KRS.WebApi
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
            builder.RegisterType<KRSUow>().As<IKRSUow>().InstancePerApiRequest();
            builder.RegisterType<RepositoryProvider>().As<IRepositoryProvider>().InstancePerApiRequest();
            builder.RegisterType<RepositoryFactories>().As<RepositoryFactories>().SingleInstance();

            builder.RegisterAssemblyTypes(typeof(RecipeRepository)
                .Assembly).Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerApiRequest();
 
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);

            var configuration = GlobalConfiguration.Configuration;
            configuration.DependencyResolver = resolver;
        }
    }
}