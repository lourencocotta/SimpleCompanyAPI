

using CompanyAPI.Core.Entities;
using CompanyAPI.Core.IRepositories;
using CompanyAPI.Tests.Repositories.TestData;

namespace CompanyAPI.Tests.Repositories
{
    public class MocksFactory
    {
        public static ICompanyRepository CompaniesRepository
        {
            get { return CompaniesRepositoryMock.Create(); }
        }

     
    }
}
