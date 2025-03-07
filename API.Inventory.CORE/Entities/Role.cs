using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE.Entities
{
    public class Role
    {
        public int ROLE_INVENTORY_ID { get; set; }
        public string ROLE_NAME { get; set; }
        public DateTime CREATED_BY { get; set; }
        public DateTime UPDATED_BY { get; set; }
    }
}
