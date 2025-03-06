using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE.Entities
{
    public class AsignacionEpp
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int EppId { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public bool Estado { get; set; }
        public string Observacion { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
