using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE.Entities
{
    public class InspeccionEpp
    {
        public int INSPECCION_EPP_ID { get; set; }
        public int ASIGNACION_EPP_ID { get; set; }
        public DateTime FECH_INSPECCION { get; set; }
        public string RESULTADO { get; set; }
        public string OBSERVACIONES { get; set; }
        public DateTime CREATED_BY { get; set; }
        public DateTime UPDATED_BY { get; set; }

    }
}
