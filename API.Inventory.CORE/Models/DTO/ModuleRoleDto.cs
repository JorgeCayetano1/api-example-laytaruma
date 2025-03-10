namespace API.Inventory.CORE.Models.DTO;

public class ModuleRoleDto
{
    public int ModuleRoleId { get; set; }
    public int ModuleInventoryId { get; set; }
    public int RoleInventoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}