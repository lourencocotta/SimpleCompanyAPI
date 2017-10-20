using AutoMapper;
using CompanyAPI.Core.Entities;
using CompanyAPI.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyAPI.Models.ResponseModels
{
    public class CompanyResponseModel : IMapFrom<Company>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Exchange { get; set; }
        public string Ticker { get; set; }
        public string Isin { get; set; }
        public string WebSite { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Company, CompanyResponseModel>();
        }
    }
}