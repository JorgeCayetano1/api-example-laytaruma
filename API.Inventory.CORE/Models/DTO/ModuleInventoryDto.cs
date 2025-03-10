namespace API.Inventory.CORE.Models.DTO;

public class ModuleInventoryDto
{
    public int ModuleInventoryId { get; set; }
    public string ModuleName { get; set; }
    public string ModuleDescription { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}