using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

using Ninject;
using Ninject.Web.Common;
using CompanyAPI.Core.Infrastructure;
using CompanyAPI.Core.IRepositories;
using CompanyAPI.Core.Repositories;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CompanyAPI.NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CompanyAPI.NinjectConfig), "Stop")]


namespace CompanyAPI
{

    public static class NinjectConfig
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static Action<IKernel> RebindAction { get; set; } // should be used only in integration testing scenarios

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                if (RebindAction != null)
                {
                    RebindAction(kernel);
                }

                ObjectFactory.Initialize(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICompanyRepository>().To<CompanyRepository>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
        }
    }
}
