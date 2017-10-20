using CompanyAPI.Core.Entities;
using CompanyAPI.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.Core.Repositories
{
    public class CompanyRepository: ICompanyRepository
    {
        private readonly IRepository<Company> _companyRepository;

        public CompanyRepository(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Company Get(int id)
        {
            return _companyRepository.Get(id);
        }
        
        public IQueryable<Company> Get()
        {
            return _companyRepository.Get();
        }

        public bool Save(Company company)
        {
            _companyRepository.AddOrUpdate(company);
            return _companyRepository.Commit();
        }

    }
}
