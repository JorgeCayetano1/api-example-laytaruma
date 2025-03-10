namespace API.Inventory.CORE.Models.DTO;

public class RoleInventoryDto
{
    public int RoleInventoryId { get; set; }
    public string RoleName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}