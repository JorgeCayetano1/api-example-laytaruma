using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE.Entities
{
    public class Module
    {
        public int MODULE_INVENTORY_ID { get; set; }
        public string MODULE_NAME { get; set; }
        public string MODULE_DESCRIPTION { get; set; }
        public DateTime CREATED_BY { get; set; }
        public DateTime UPDATED_BY { get; set; }
    }
}
