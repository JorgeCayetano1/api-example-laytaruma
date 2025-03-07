using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE.Entities
{
    public class ProveedorEpp
    {
        public int PROVEEDOR_EPP_ID { get; set; }
        public string NOMBRE { get; set; }
        public string FECH_ENTREGA { get; set; }
        public DateTime CREATED_BY { get; set; }
        public DateTime UPDATED_BY { get; set; }
    }
}
