using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Models
{
  public class Multimodelclass
    {
        public Product  P { get; set; }
        public Order O { get; set; }
        public Multimodelclass(Product a, Order b)
        {
            this.P = a;
            this.O = b;
        }
    }
}
