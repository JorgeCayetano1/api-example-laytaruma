namespace API.Inventory.CORE.Entities;

public class ModuleRole
{
    public int MODULE_ROLE_ID { get; set; }
    public int MODULE_INVENTORY_ID { get; set; }
    public int ROLE_INVENTORY_ID { get; set; }
    public DateTime CREATED_AT { get; set; }
    public DateTime UPDATED_AT { get; set; }
}