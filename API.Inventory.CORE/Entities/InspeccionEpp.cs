using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE.Entities
{
    public class InspeccionEpp
    {
        public int Id { get; set; }
        public int AsignacionEppId { get; set; }
        public DateTime FechaInspeccion { get; set; }
        public string Observacion { get; set; }
        public bool Estado { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
