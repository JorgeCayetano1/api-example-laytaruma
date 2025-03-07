using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE.Entities
{
    public class Epp
    {
        public int EPP_ID { get; set; }
        public int TIPO_EPP_ID { get; set; }
        public int PROVEEDOR_EPP_ID { get; set; }
        public int SEDE_ID { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal COSTO { get; set; }
        public DateTime CREATED_BY { get; set; }
        public DateTime UPDATED_BY { get; set; }
    }
}
