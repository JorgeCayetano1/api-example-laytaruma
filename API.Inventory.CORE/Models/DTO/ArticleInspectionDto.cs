namespace API.Inventory.CORE.Models.DTO;

public class ArticleInspectionDto
{
    public int InspectionId { get; set; }
    public int AssignmentId { get; set; }
    public DateTime InspectionDate { get; set; }
    public int InspectorId { get; set; }
    public string Result { get; set; }
    public string Observations { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}