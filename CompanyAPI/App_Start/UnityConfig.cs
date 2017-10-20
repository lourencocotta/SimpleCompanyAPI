using CompanyAPI.Core.IRepositories;
using CompanyAPI.Core.Repositories;
using Microsoft.Practices.Unity;
using System;
using System.Web.Http;
using Unity.WebApi;

namespace CompanyAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ICompanyRepository, CompanyRepository>(new HierarchicalLifetimeManager());
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }


}