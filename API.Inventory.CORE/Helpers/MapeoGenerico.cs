using AutoMapper;
using API.Inventory.CORE.Entities;
using API.Inventory.CORE.Models.DTO;

namespace API.Inventory.CORE.Helpers
{
    public class MapeoGenerico : Profile
    {
        public MapeoGenerico()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.USER_INVENTORY_ID))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.USER_NAME))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.USER_EMAIL))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.USER_PASSWORD));
            // .ForMember(dest => dest., opt => opt.MapFrom(src => src.CREATED_BY))
            
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.USER_INVENTORY_ID, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.USER_NAME, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.USER_EMAIL, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.USER_PASSWORD, opt => opt.MapFrom(src => src.Password));
        }
    }
}
