using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CodeCamper.Data;
using CodeCamper.Data.Contracts;
using CodeCamper.Data.Helpers;
using CodeCamper.Web;
using Ninject;

namespace CodeCamper.WebApi.App_Start
{
    public class IocConfig
    {
        public static  void RegusterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel();

            kernel.Bind<ICodeCamperUow>().To<CodeCamperUow>();

            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>()
                .InSingletonScope();

            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
        
            config.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}