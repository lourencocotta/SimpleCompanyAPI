using CompanyAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.Tests.Repositories.TestData
{
    public class CompanyTestData
    {
        public static List<Company> Get()
        {
            return new List<Company>
            {
               new Company(){Id=1,Name="Apple Inc.", Exchange="NASDAQ", Ticker="AAPL", Isin="US0378331005", WebSite="http://www.apple.com"} ,
               new Company(){Id=2,Name="British Airways Plc", Exchange="Pink Sheets", Ticker="BAIRY", Isin="US1104193065", WebSite=""} ,
               new Company(){Id=3,Name="Heineken NV", Exchange="Euronext Amsterdam", Ticker="HEIA", Isin="NL0000009165", WebSite=""} ,
               new Company(){Id=4,Name="Panasonic Corp", Exchange="Tokyo Stock Exchange", Ticker="6752", Isin="JP3866800000", WebSite="http://www.panasonic.co.jp"} ,
               new Company(){Id=5,Name="Porsche Automobil", Exchange="Deutsche Börse", Ticker="PAH3", Isin="DE000PAH0038", WebSite="https://www.porsche.com/"}

            };
        }
    }
}
