using Microsoft.Owin;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(CompanyAPI.Startup))]

namespace CompanyAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutoMapperConfig.RegisterMappings(Assembly.GetExecutingAssembly());

            app.UseNinjectMiddleware(NinjectConfig.CreateKernel);

            var config = new HttpConfiguration();

            WebApiConfig.Register(config);

            app.UseNinjectWebApi(config);
        }
    }
}