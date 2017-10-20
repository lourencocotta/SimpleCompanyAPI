using AutoMapper;

namespace CompanyAPI.Mappings
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}