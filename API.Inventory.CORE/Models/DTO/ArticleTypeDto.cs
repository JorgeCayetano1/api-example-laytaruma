namespace API.Inventory.CORE.Models.DTO;

public class ArticleTypeDto
{
    public int ArticleTypeId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}