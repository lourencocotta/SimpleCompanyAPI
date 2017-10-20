using System.Collections.Generic;
using System.Linq;
using Moq;
using CompanyAPI.Core.IRepositories;
using CompanyAPI.Core.Entities;

namespace CompanyAPI.Tests.Repositories.TestData
{
    public class CompaniesRepositoryMock
    {
        public static ICompanyRepository Create()
        {
            var listOfCompanies = new List<Company>();
            for (int i = 0; i < 20; i++)
            {
                listOfCompanies.Add(new Company
                {
                    Id = i,
                    Name = "Company " + i,
                    Exchange = "Exchange" + i,
                    Ticker = "TIVC" + i,
                    Isin = "IS00000091" + i,
                    WebSite = "www.sit" + i+".com.br"
                });
            }

            var repository = new Mock<ICompanyRepository>();
            repository.Setup(r => r.Get()).Returns(listOfCompanies.AsQueryable());
            repository.Setup(r => r.Get(It.IsAny<int>())).Returns(listOfCompanies.Where(x => x.Id ==1).FirstOrDefault());
            repository.Setup(d => d.Save(It.IsAny<Company>())).Callback<Company>((s) => listOfCompanies.Add(s)).Returns(true);
            
            return repository.Object;
        }
    }
}
