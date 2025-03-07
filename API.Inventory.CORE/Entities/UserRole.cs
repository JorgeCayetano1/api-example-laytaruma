using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE.Entities
{
    public class UserRole
    {
        public int USER_ROLE_ID { get; set; }
        public int USER_INVENTORY_ID { get; set; }
        public int ROLE_INVENTORY_ID { get; set; }
        public DateTime CREATED_BY { get; set; }
        public DateTime UPDATED_BY { get; set; }
    }
}
