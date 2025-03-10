namespace API.Inventory.CORE.Models.DTO;

public class SupplierDto
{
    public int SupplierId { get; set; }
    public string Name { get; set; }
    public DateTime DeliveryDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}