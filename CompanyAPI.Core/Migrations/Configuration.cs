namespace CompanyAPI.Core.Migrations
{
    using CompanyAPI.Core.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CompanyAPI.Core.Repositories.EfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CompanyAPI.Core.Repositories.EfDbContext context)
        {
            context.Company.AddOrUpdate(
               new Company() { Name = "Apple Inc.", Exchange = "NASDAQ", Ticker = "AAPL", Isin = "US0378331005", WebSite = "http://www.apple.com" },
               new Company() { Name = "British Airways Plc", Exchange = "Pink Sheets", Ticker = "BAIRY", Isin = "US1104193065", WebSite = "" },
               new Company() { Name = "Heineken NV", Exchange = "Euronext Amsterdam", Ticker = "HEIA", Isin = "NL0000009165", WebSite = "" },
               new Company() { Name = "Panasonic Corp", Exchange = "Tokyo Stock Exchange", Ticker = "6752", Isin = "JP3866800000", WebSite = "http://www.panasonic.co.jp" },
               new Company() { Name = "Porsche Automobil", Exchange = "Deutsche Börse", Ticker = "PAH3", Isin = "DE000PAH0038", WebSite = "https://www.porsche.com/" });

               
        }
    }
}
