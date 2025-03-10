namespace API.Inventory.CORE.Entities;

public class ModuleInventory
{
    public int MODULE_INVENTORY_ID { get; set; }
    public string MODULE_NAME { get; set; }
    public string MODULE_DESCRIPTION { get; set; }
    public DateTime CREATED_AT { get; set; }
    public DateTime UPDATED_AT { get; set; }
    public DateTime DELETED_AT { get; set; }
}