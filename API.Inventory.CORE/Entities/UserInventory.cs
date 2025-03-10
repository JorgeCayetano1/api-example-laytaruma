namespace API.Inventory.CORE.Entities;

public class UserInventory
{
    public int USER_INVENTORY_ID { get; set; }
    public string USER_NAME { get; set; }
    public string USER_EMAIL { get; set; }
    public string USER_PASSWORD { get; set; }
    public DateTime CREATED_AT { get; set; }
    public DateTime UPDATED_AT { get; set; }
    public DateTime DELETED_AT { get; set; }
}