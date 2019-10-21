using AutoMapper;
using KVSolution.PIM.Application.Blogs.Request;
using KVSolution.PIM.Application.Customer.Request;

namespace KVSolution.PIM.Application.Mapping
{
    public static class MappingConfiguration
    {
        public static void Execute()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Domain.Entities.Customer, CustomerModel>();
                cfg.CreateMap<Domain.Entities.Blog, BlogModel>();
            });
        }
    }
}
