namespace API.Inventory.CORE.Models.DTO;

public class StockDto
{
    public int StockId { get; set; }
    public int ArticleId { get; set; }
    public int LocationId { get; set; }
    public int Quantity { get; set; }
    public int MinStock { get; set; }
    public int MaxStock { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}