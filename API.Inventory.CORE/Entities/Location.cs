namespace API.Inventory.CORE.Entities;

public class Location
{
    public int LOCATION_ID { get; set; }
    public string NAME { get; set; }
    public string ADDRESS { get; set; }
    public DateTime CREATED_AT { get; set; }
    public DateTime UPDATED_AT { get; set; }
    public DateTime DELETED_AT { get; set; }
}