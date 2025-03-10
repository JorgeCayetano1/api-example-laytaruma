namespace API.Inventory.CORE.Models.DTO;

public class AuditLogDto
{
    public int AuditId { get; set; }
    public string TableName { get; set; }
    public string RecordId { get; set; }
    public string Action { get; set; }
    public string UserId { get; set; }
    public DateTime TimeStamp { get; set; }
}