﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE.Entities
{
    public class Stock
    {
        public int STOCK_ID { get; set; }
        public int EPP_ID { get; set; }
        public int SEDE_ID { get; set; }
        public int CANTIDAD { get; set; }
        public DateTime CREATED_BY { get; set; }
        public DateTime UPDATED_BY { get; set; }
    }
}
