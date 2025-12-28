using AutoMapper;
using scafoldold.Models;   

namespace scafoldold.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDTO>();
            //CreateMap<OrderDTO, Order>();
            CreateMap<OrderDTO, Order>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) 
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
