namespace API.Inventory.CORE.Entities;

public class ArticleAssignment
{
    public int ASSIGNMENT_ID { get; set; }
    public int EMPLOYEE_ID { get; set; }
    public int ARTICLE_ID { get; set; }
    public DateTime ASSIGN_DATE { get; set; }
    public DateTime RETURN_DATE { get; set; }
    public string ASSIGNMENT_STATUS { get; set; }
    public string COMMENTS { get; set; }
    public DateTime CREATED_AT { get; set; }
    public DateTime UPDATED_AT { get; set; }
}