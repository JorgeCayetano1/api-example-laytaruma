namespace API.Inventory.CORE.Models.DTO;

public class LocationDto
{
    public int LocationId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}