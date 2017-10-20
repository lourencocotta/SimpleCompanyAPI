## Company API
Sample WEB API built with ASP.NET Web API. That minimalist implementation approach TDD, DI (dependency injection), basic authentication, Migration, ORM

## Some of Technologies
* ASP.NET Web API
* AutoMapper
* EntityFramework
* Ninject
* Unity
* MyTested.WebApi
* Moq

## Building the App
      
1. To build the Web API project, and build the solution to install Nuget packages. This will automatically restore Nuget packages. 
2. Change ConnectionString no web.config file according with the database Server. 

<connectionStrings>
    <add name="EfDbContext" providerName="System.Data.SqlClient" connectionString="Data Source=<”Server Name”>;Initial Catalog=CompanyAPI;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|CompanyAPI.mdf" />
  </connectionStrings>

In Visual Studio menu: View > Other Windows > Package Manager Console 
Execute the command : Update-Database

3. Run the Application.
4. Restlet Client is a very friendly application to check it. 

