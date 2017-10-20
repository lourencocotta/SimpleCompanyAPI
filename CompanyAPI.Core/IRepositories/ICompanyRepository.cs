using CompanyAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.Core.IRepositories
{
    public interface ICompanyRepository
    {
        Company Get(int id);
        IQueryable<Company> Get();
        bool Save(Company company);
    }
}
