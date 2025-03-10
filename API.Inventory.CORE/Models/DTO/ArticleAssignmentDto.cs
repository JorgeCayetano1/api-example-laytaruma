namespace API.Inventory.CORE.Models.DTO;

public class ArticleAssignmentDto
{
    public int AssignmentId { get; set; }
    public int EmployeeId { get; set; }
    public int ArticleId { get; set; }
    public DateTime AssignDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public string AssignmentStatus { get; set; }
    public string Comments { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}