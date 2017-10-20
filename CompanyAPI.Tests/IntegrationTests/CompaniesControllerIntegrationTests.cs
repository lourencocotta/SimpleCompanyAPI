using CompanyAPI.Models.ResponseModels;
using CompanyAPI.Tests.Repositories;
using CompanyAPI.Core.IRepositories;
using MyTested.WebApi;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.Tests.IntegrationTests
{
    [TestFixture]
    class CompaniesControllerIntegrationTests
    {
        private IServerBuilder server;
        private string accessToken;

        [OneTimeSetUp]
        public void Init()
        {
            NinjectConfig.RebindAction = kernel =>
            {
                kernel.Rebind<ICompanyRepository>().ToConstant(MocksFactory.CompaniesRepository);
            };

            this.server = MyWebApi.Server().Starts<Startup>();

        }

        [Test]
        public void BooksControllerShouldBlockForUnauthorizedMethod()
        {
            server
                .WithHttpRequestMessage(req => req
                    .WithRequestUri("/api/Companies/1")
                    .WithMethod(HttpMethod.Get))
                .ShouldReturnHttpResponseMessage()
                .WithStatusCode(HttpStatusCode.Unauthorized);
                
        }

        [Test]
        public void BooksControllerShouldReturnCorrectCompanyForAuthorizedMethod()
        {
            server
                .WithHttpRequestMessage(req => req
                    .WithRequestUri("/api/Companies")
                    //.WithHeader("APIKey", "5567GGH67225HYVGG"))
                    .WithMethod(HttpMethod.Get))
                .ShouldReturnHttpResponseMessage()
                .WithStatusCode(HttpStatusCode.OK);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            MyWebApi.Server().Stops();
        }

      
    }

}
