using System.Reflection;
using CompanyAPI;
using MyTested.WebApi;
using NUnit.Framework;

[SetUpFixture]
public class TestsStartup
{
    [OneTimeSetUp]
    public void SetUpTests()
    {
        AutoMapperConfig.RegisterMappings(Assembly.Load("CompanyAPI"));

        MyWebApi.IsRegisteredWith(WebApiConfig.Register);
    }
}