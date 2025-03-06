using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public int EppId { get; set; }
        public int SedeId { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
