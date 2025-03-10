namespace API.Inventory.CORE.Entities;

public class AuditLog
{
    public int AUDIT_ID { get; set; }
    public string TABLE_NAME { get; set; }
    public string RECORD_ID { get; set; }
    public string ACTION { get; set; }
    public int USER_ID { get; set; }
    public DateTime TIMESTAMP { get; set; }
}