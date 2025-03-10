namespace API.Inventory.CORE.Entities;

public class Article
{
    public int ARTICLE_ID { get; set; }
    public int ARTICLE_TYPE_ID { get; set; }
    public int LOCATION_ID { get; set; }
    public string NAME { get; set; }
    public string DESCRIPTION { get; set; }
    public decimal COST { get; set; }
    public DateTime CREATED_AT { get; set; }
    public DateTime UPDATED_AT { get; set; }
    public DateTime DELETED_AT { get; set; }
}