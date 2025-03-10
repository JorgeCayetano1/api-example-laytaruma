namespace API.Inventory.CORE.Entities;

public class Stock
{
    public int STOCK_ID { get; set; }
    public int ARTICLE { get; set; }
    public int LOCATION_ID { get; set; }
    public int QUANTITY { get; set; }
    public int MIN_STOCK { get; set; }
    public int MAX_STOCK { get; set; }
    public DateTime CREATED_AT { get; set; }
    public DateTime UPDATED_AT { get; set; }
}