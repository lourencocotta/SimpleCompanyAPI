using CompanyAPI.Core.Entities;
using CompanyAPI.Core.IRepositories;
using CompanyAPI.Core.Repositories;
using CompanyAPI.Tests.Repositories.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CompanyAPI.Tests.Repositories
{
    [TestClass]
    public class CompanyRepositoryTests
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly RepositoryList<Company> _repository;
        
        public CompanyRepositoryTests()
        {
            _repository = new RepositoryList<Company>(CompanyTestData.Get());
            _companyRepository = new CompanyRepository(_repository);
        }

        [TestMethod]
        public void CompanyRepository_Save_New()
        {
            var company = new Company(){Name = "NewCompany", Exchange = "NewExchange", Ticker = "NEWL", Isin = "NEW378331005", WebSite = "http://www.new.com"};

            var totalBeforeDeSave = _repository.Get().Count();
            _companyRepository.Save(company);
            var totalAfterDeSave = _repository.Get().Count();

            Assert.IsTrue(_repository.Commited);
            Assert.AreEqual(totalBeforeDeSave + 1, totalAfterDeSave);
        }

        [TestMethod]
        public void CompanyRepository_Save_Registered()
        {
            var company = _repository.First();
            company.Exchange = "NASDAQ_updated";

            var totalBeforeDeSave = _repository.Get().Count();
            _companyRepository.Save(company);
            var totalAfterDeSave = _repository.Get().Count();

            Assert.IsTrue(_repository.Commited);
            Assert.AreEqual(totalBeforeDeSave, totalAfterDeSave);
            Assert.AreEqual(company.Exchange, _repository.First().Exchange);
        }

        [TestMethod]
        public void CompanyRepository_Get_Id()
        {
            var company = _repository.First();
            Assert.AreEqual(company, _companyRepository.Get(company.Id));
        }

        [TestMethod]
        public void CompanyRepository_Get_ISIN()
        {
            var company = _repository.First();
            Assert.AreEqual(company, _companyRepository.Get().Where(x=>x.Isin.Equals(company.Isin)).FirstOrDefault());
        }

        [TestMethod]
        public void CompanyRepository_GetAll()
        {
            var companyList = _repository.Get().Count();
            Assert.AreEqual(companyList, _companyRepository.Get().Count());
        }
    }
}
