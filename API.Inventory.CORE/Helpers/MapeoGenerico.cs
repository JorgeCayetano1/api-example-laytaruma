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
            
            CreateMap<RoleInventory, RoleInventoryDto>()
                .ForMember(dest => dest.RoleInventoryId, opt => opt.MapFrom(src => src.ROLE_INVENTORY_ID))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.ROLE_NAME))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CREATED_AT))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UPDATED_AT))
                .ForMember(dest => dest.DeletedAt, opt => opt.MapFrom(src => src.DELETED_AT));

            CreateMap<RoleInventoryDto, RoleInventory>()
                .ForMember(dest => dest.ROLE_INVENTORY_ID, opt => opt.MapFrom(src => src.RoleInventoryId))
                .ForMember(dest => dest.ROLE_NAME, opt => opt.MapFrom(src => src.RoleName))
                .ForMember(dest => dest.CREATED_AT, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UPDATED_AT, opt => opt.MapFrom(src => src.UpdatedAt))
                .ForMember(dest => dest.DELETED_AT, opt => opt.MapFrom(src => src.DeletedAt));
            
            CreateMap<ModuleInventory, ModuleInventoryDto>()
                .ForMember(dest => dest.ModuleInventoryId, opt => opt.MapFrom(src => src.MODULE_INVENTORY_ID))
                .ForMember(dest => dest.ModuleName, opt => opt.MapFrom(src => src.MODULE_NAME))
                .ForMember(dest => dest.ModuleDescription, opt => opt.MapFrom(src => src.MODULE_DESCRIPTION))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CREATED_AT))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UPDATED_AT))
                .ForMember(dest => dest.DeletedAt, opt => opt.MapFrom(src => src.DELETED_AT));
            
            CreateMap<ModuleInventoryDto, ModuleInventory>()
                .ForMember(dest => dest.MODULE_INVENTORY_ID, opt => opt.MapFrom(src => src.ModuleInventoryId))
                .ForMember(dest => dest.MODULE_NAME, opt => opt.MapFrom(src => src.ModuleName))
                .ForMember(dest => dest.MODULE_DESCRIPTION, opt => opt.MapFrom(src => src.ModuleDescription))
                .ForMember(dest => dest.CREATED_AT, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UPDATED_AT, opt => opt.MapFrom(src => src.UpdatedAt))
                .ForMember(dest => dest.DELETED_AT, opt => opt.MapFrom(src => src.DeletedAt));
        }
    }
}
