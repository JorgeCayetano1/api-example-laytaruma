namespace API.Inventory.CORE.Models.DTO;

public class ArticleDto
{
    public int ArticleId { get; set; }
    public int ArticleTypeId { get; set; }
    public int SupplierId { get; set; }
    public int LocationId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Cost { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}