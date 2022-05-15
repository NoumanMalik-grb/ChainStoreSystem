using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Models
{
    public class ProductViewModel
    {
       
        public int ProductViewId { get; set; }
     
        public String ProductName { get; set; }
      
        public String Product_Picture { get; set; }
       
        public String Product_Discription_Max { get; set; }
        public String Product_Discription_Min { get; set; }
       
        public decimal Product_Sale_Price { get; set; }
      
        public decimal Product_Purchase_Price { get; set; }
       
        public int Product_Quantity { get; set; }
      
        public String Product_Status { get; set; }
        public decimal Product_Discount { get; set; }
       
        public DateTime Product_Add_Date { get; set; }
       
        public DateTime Product_Exp_Date { get; set; }
        
        // order detail with product
        public IList<OrderDetail> ProOrderDetails { get; set; }

    }
}