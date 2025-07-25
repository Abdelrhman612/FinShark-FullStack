using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.dto
{
    public class CreateStockDto
    {
        public string Sympol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
    }
}