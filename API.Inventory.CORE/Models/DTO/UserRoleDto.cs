namespace API.Inventory.CORE.Models.DTO;

public class UserRoleDto
{
    public int UserRoleId { get; set; }
    public int UserInventoryId { get; set; }
    public int RoleInventoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}