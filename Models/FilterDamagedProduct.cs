using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Models
{
    public class FilterDamagedProduct
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? GetVArea { get; set; }
        public int? GetVProduct { get; set; }
    }
}
