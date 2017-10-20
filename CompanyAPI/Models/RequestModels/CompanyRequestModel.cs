using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyAPI.Models.RequestModels
{
    public class CompanyRequestModel
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Exchange { get; set; }

        [Required]
        public string Ticker { get; set; }

        [Required]
        public string Isin { get; set; }

        public string WebSite { get; set; }

        }
}