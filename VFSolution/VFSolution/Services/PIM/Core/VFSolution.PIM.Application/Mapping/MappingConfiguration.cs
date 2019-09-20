using AutoMapper;
using VFSolution.PIM.Application.Customer.Request;

namespace VFSolution.PIM.Application.Mapping
{
    public static class MappingConfiguration
    {
        public static void Execute()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Domain.Entities.Customer, CustomerModel>();
            });
        }
    }
}
