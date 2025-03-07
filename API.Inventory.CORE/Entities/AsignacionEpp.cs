using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE.Entities
{
    public class AsignacionEpp
    {
        public int ASIGNACION_EPP_ID { get; set; }
        public int EMPLEADO_ID { get; set; }
        public int EPP_ID { get; set; }
        public DateTime FECH_ASIGNACION { get; set; }
        public DateTime FECH_DEVOLUCION { get; set; }
        public bool ESTADO_EPP { get; set; }
        public string COMENTARIO { get; set; }
        public DateTime CREATED_BY { get; set; }
        public DateTime UPDATED_BY { get; set; }
    }
}
