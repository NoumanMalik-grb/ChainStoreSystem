using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
       [Required]
        public String Order_Name { get; set; }
        [Required]
        public String  Order_City { get; set; }
        [Required]
        public String Order_Type { get; set; }
        [Required]
        public string Order_Status { get; set; }
        [Required]
        public String Order_Delivery_Status { get; set; }
        [Required]
        public DateTime Order_DateTime { get; set; } 
        [Required]
        public String Area { get; set; }
        //foreign key
        //[Display(Name ="Product")]
        //[ForeignKey("Product_FId")]
        //public  int Product_Fid { get; set; }
        //public virtual Product Products { get; set; }
        // order details in order
        public virtual ICollection<OrderDetail> Order_Detail { get; set; }
    }
}
