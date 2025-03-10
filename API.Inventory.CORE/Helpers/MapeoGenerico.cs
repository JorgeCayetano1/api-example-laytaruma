using API.Inventory.CORE.Entities;
using API.Inventory.CORE.Models.DTO;
using AutoMapper;

namespace API.Inventory.CORE.Helpers
{
    public class MapeoGenerico : Profile
    {
        public MapeoGenerico()
        {
            CreateMap<UserInventory, UserInventoryDto>()
                .ForMember(dest => dest.UserInventoryId, opt => opt.MapFrom(src => src.USER_INVENTORY_ID))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.USER_NAME))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.USER_EMAIL))
                .ForMember(dest => dest.UserPassword, opt => opt.MapFrom(src => src.USER_PASSWORD))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CREATED_AT))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UPDATED_AT))
                .ForMember(dest => dest.DeletedAt, opt => opt.MapFrom(src => src.DELETED_AT));
            
            CreateMap<UserInventoryDto, UserInventory>()
                .ForMember(dest => dest.USER_INVENTORY_ID, opt => opt.MapFrom(src => src.UserInventoryId))
                .ForMember(dest => dest.USER_NAME, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.USER_EMAIL, opt => opt.MapFrom(src => src.UserEmail))
                .ForMember(dest => dest.USER_PASSWORD, opt => opt.MapFrom(src => src.UserPassword))
                .ForMember(dest => dest.CREATED_AT, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UPDATED_AT, opt => opt.MapFrom(src => src.UpdatedAt))
                .ForMember(dest => dest.DELETED_AT, opt => opt.MapFrom(src => src.DeletedAt));
        }
    }
}
