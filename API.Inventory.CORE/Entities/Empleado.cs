using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE.Entities
{
    public class Empleado
    {
        public int EMPLEADO_ID { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string CARGO { get; set; }
        public bool ESTADO { get; set; }
        public DateTime CREATED_BY { get; set; }
        public DateTime UPDATED_BY { get; set; }
    }
}
