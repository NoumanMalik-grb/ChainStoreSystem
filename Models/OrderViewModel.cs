using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public String Order_Name { get; set; }

        public String Order_City { get; set; }

        public String Order_Type { get; set; }

        public string Order_Status { get; set; }

        public String Order_Delivery_Status { get; set; }

        public DateTime Order_DateTime { get; set; }

        public String Area { get; set; }
        // order details in order
        public IList<OrderDetail> OrderDetails { get; set; }
    }
}
