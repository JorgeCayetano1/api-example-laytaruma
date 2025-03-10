namespace API.Inventory.CORE.Entities;

public class Employee
{
    public int EMPLOYEE_ID { get; set; }
    public string FIRST_NAME { get; set; }
    public string LAST_NAME { get; set; }
    public string POSITION { get; set; }
    public string STATUS { get; set; }
    public DateTime CREATED_AT { get; set; }
    public DateTime UPDATED_AT { get; set; }
    public DateTime DELETED_AT { get; set; }
}