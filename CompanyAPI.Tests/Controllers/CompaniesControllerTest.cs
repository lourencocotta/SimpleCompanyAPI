using System.Collections.Generic;
using System.Net.Http;
using CompanyAPI.Controllers;
using NUnit.Framework;
using MyTested.WebApi;
using CompanyAPI.Tests.Repositories;
using CompanyAPI.Models.ResponseModels;
using CompanyAPI.Models.RequestModels;
using CompanyAPI.Core.Repositories;
using CompanyAPI.Core.IRepositories;
using System;
using CompanyAPI.Core.Entities;
using System.Web.Http;
using Moq;

namespace CompanyAPI.Tests.Controllers
{
    [TestFixture]
    public class CompaniesControllerTest
    {
        private IControllerBuilder<CompaniesController> controller;

        private readonly ICompanyRepository _companyRepository;

        [SetUp]
        public void TestInit()
        {
            this.controller = MyWebApi
                .Controller<CompaniesController>()
                .WithResolvedDependencyFor(MocksFactory.CompaniesRepository);
        }

        [Test]
        public void VerifyChangePasswordMethodIsDecoratedWithAuthorizeAttribute()
        {
            var controller = new CompaniesController(_companyRepository);
            var type = controller.GetType();
            var methodInfo = type.GetMethod("GetCompany");
            var attributes = methodInfo.GetCustomAttributes(typeof(AuthenticationFilter), true);
            Assert.IsTrue(attributes.Length>0, "No AuthenticationFilter found on GetCompany(int id) method");
        }

        [Test]
        public void ReturnCompanies()
        {
            this.controller
                .WithAuthenticatedUser()
                .Calling(c => c.GetCompanies())
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<CompanyResponseModel>>();
        }

        [Test]
        public void ReturnProperCompanyWhenUserIsAuthorizedInGetByIdAction()
        {
            this.controller
                .Calling(c => c.GetCompany(1))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<CompanyResponseModel>()
                .Passing(b => b.Id == 1);
        }

        [Test]
        public void ShouldAllowOnlyHttpPostOnCompaniesPostActionAndHave()
        {
            this.controller
                .Calling(c => c.CreateCompany(new CompanyRequestModel()))
                .ShouldHave()
                .ActionAttributes(attrs => attrs
                    .RestrictingForRequestsWithMethod(HttpMethod.Post)
                    .AndAlso())
                .AndAlso()
                .ShouldReturn()
                .BadRequest()
                .WithModelStateFor<CompanyRequestModel>()
                .ContainingModelStateErrorFor(b => b.Name)
                .AndAlso()
                .ContainingModelStateErrorFor(m => m.Exchange)
                .AndAlso()
                .ContainingModelStateErrorFor(b => b.Isin)
                .AndAlso()
                .ContainingModelStateErrorFor(b => b.Ticker);
        }

        [Test]
        public void ShouldReturnBadRequestWhenNameIsEmpty()
        {
            this.controller
                .Calling(c => c.CreateCompany(new CompanyRequestModel
                {
                    Name = string.Empty,
                    Exchange = "Valid Exchange",
                    Isin = "10ISIN",
                    Ticker = "Valid Ticker",
                    WebSite = ""
                }))
                .ShouldReturn()
                .BadRequest()
                .WithModelStateFor<CompanyRequestModel>()
                .ContainingModelStateErrorFor(b => b.Name)
                .ThatEquals("The Name field is required.");
        }

        [Test]
        public void ShouldReturnBadRequestWhenExchangeIsEmpty()
        {
            this.controller
                .Calling(c => c.CreateCompany(new CompanyRequestModel
                {
                    Name = "valid Name",
                    Exchange = string.Empty,
                    Isin = "10ISIN",
                    Ticker = "Valid Ticker",
                    WebSite = ""
                }))
                .ShouldReturn()
                .BadRequest()
                .WithModelStateFor<CompanyRequestModel>()
                .ContainingModelStateErrorFor(b => b.Exchange)
                .ThatEquals("The Exchange field is required.");
        }

        [Test]
        public void ShouldReturnBadRequestWhenIsinIsEmpty()
        {
            this.controller
                .Calling(c => c.CreateCompany(new CompanyRequestModel
                {
                    Name = "valid Name",
                    Exchange = "valid Exchange",
                    Isin = string.Empty,
                    Ticker = "Valid Ticker",
                    WebSite = ""
                }))
                .ShouldReturn()
                .BadRequest()
                .WithModelStateFor<CompanyRequestModel>()
                .ContainingModelStateErrorFor(b => b.Isin)
                .ThatEquals("The Isin field is required.");
        }

        [Test]
        public void ShouldReturnBadRequestWhenIsinHasFirstTwoCharactersNumbers()
        {
            this.controller
                .Calling(c => c.CreateCompany(new CompanyRequestModel
                {
                    Name = "valid Name",
                    Exchange = "valid Exchange",
                    Isin = "99Invalid Isin",
                    Ticker = "Valid Ticker",
                    WebSite = ""
                    
                }))
                .ShouldReturn()
                .BadRequest()
                .WithErrorMessage("The first two characters of an ISIN must NOT be numeric.");
        }
        [Test]
        public void ShouldReturnBadRequestWhenTickerIsEmpty()
        {
            this.controller
                .Calling(c => c.CreateCompany(new CompanyRequestModel
                {
                    Name = "valid Name",
                    Exchange = "valid Exchange",
                    Isin = "10ISIN",
                    Ticker = string.Empty,
                    WebSite = ""
                }))
                .ShouldReturn()
                .BadRequest()
                .WithModelStateFor<CompanyRequestModel>()
                .ContainingModelStateErrorFor(b => b.Ticker)
                .ThatEquals("The Ticker field is required.");
        }

        [Test]
        public void ShouldReturnCreatedWhenCompanyIsFoundAndModelStateIsValid()
        {
            
            this.controller
                .Calling(
                    c =>
                        c.CreateCompany(new CompanyRequestModel
                        {
                            Id = 1,
                            Name = "Valid Name",
                            Exchange = "Valid Exchange",
                            Ticker = "Valid Ticker",
                            Isin = "IS7999799",
                            WebSite = "Valid WebSite"
                        }))
                .ShouldHave()
                .ValidModelState()
                .AndAlso()
                .ShouldReturn()
                .Ok();
                
        }
    }
}
