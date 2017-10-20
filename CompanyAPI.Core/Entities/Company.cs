using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyAPI.Core.Contracts;

namespace CompanyAPI.Core.Entities
{
    public class Company: EntityBase
    {
        public string Name { get; set; }
        public string Exchange { get; set; }
        public string Ticker { get; set; }
        public string Isin { get; set; }
        public string WebSite { get; set; }
    }
}
