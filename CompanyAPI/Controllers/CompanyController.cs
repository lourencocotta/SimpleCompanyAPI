using CompanyAPI.Core.Entities;
using CompanyAPI.Core.IRepositories;
using CompanyAPI.Models.RequestModels;
using CompanyAPI.Models.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace CompanyAPI.Controllers
{

    [Route("api/[controller]")]
    public class CompaniesController : ApiController
    {
        private ICompanyRepository _companyRepository;

        public CompaniesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        /// <summary>
        /// Get a list of companies.
        /// </summary>
        // GET: api/companies
        [Route("api/Companies")]
        public IHttpActionResult GetCompanies()
        {
            return this.Ok(this._companyRepository.Get().ProjectTo<CompanyResponseModel>().ToList());

        }

        [AuthenticationFilter]
        /// <summary>
        /// Get a list of companies.
        /// </summary>
        // GET: api/companies/1
        [Route("api/Companies/{id}")]
        public IHttpActionResult GetCompany(int id)
        {
            return this.Ok(new List<Company>()
                        { _companyRepository.Get(id)}
                    .AsQueryable()
                    .ProjectTo<CompanyResponseModel>()
                    .FirstOrDefault());
            
        }

        /// <summary>
        /// Get a list of companies.
        /// </summary>
        // GET: api/companies/1
        [Route("api/Companies/ISIN/{isin}")]
        public IHttpActionResult GetCompanyByIsin(string isin)
        {
            return this.Ok(this._companyRepository
                .Get()
                .Where(x=>x.Isin.Equals(isin))
                .ProjectTo<CompanyResponseModel>()
                .FirstOrDefault());
        }

        /// <summary>
        /// Register a new company.
        /// </summary>
        // Create/Edit: api/Companies  
        [Route("api/Companies")]
        [HttpPost]
        public IHttpActionResult CreateCompany(CompanyRequestModel company)
        {
            if (company == null)
            {
                return this.BadRequest("Comapny does not exist!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (int.TryParse(company.Isin.Substring(0, 2), out var value))
            {
                return this.BadRequest("The first two characters of an ISIN must NOT be numeric.");
            }

            if (_companyRepository.Get().Where(x=>x.Isin.Equals(company.Isin)).Any()) {
                return this.BadRequest("Isin already exists!");
            }

            var newCompany = new Company() { Id = company.Id, Name = company.Name, Exchange = company.Exchange, Isin = company.Isin, Ticker = company.Ticker, WebSite = company.WebSite };
                

            if (_companyRepository.Save(newCompany))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

    }
}
