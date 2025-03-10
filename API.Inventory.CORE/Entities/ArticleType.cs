namespace API.Inventory.CORE.Entities;

public class ArticleType
{
    public int ARTICLE_TYPE_ID { get; set; }
    public string NAME { get; set; }
    public DateTime CREATED_AT { get; set; }
    public DateTime UPDATED_AT { get; set; }
    public DateTime DELETED_AT { get; set; }
}