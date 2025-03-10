namespace API.Inventory.CORE.Entities;

public class ArticleInspection
{
    public int INSPECTION_ID { get; set; }
    public int ASSIGNMENT_ID { get; set; }
    public DateTime INSPECTION_DATE { get; set; }
    public int INSPECTOR_ID { get; set; }
    public string RESULT { get; set; }
    public string OBSERVATIONS { get; set; }
    public DateTime CREATED_AT { get; set; }
    public DateTime UPDATED_AT { get; set; }
    
}