using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Models
{
    public class OrderDetail
    {
       
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Sale_Price { get; set; }
        [Required]
        public decimal Purchase_Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        ////foreign key Prodcut
        [Display(Name = "Product")]
        [ForeignKey("Product_FId")]
        public int Product_FId { get; set; }
        public virtual Product Products { get; set; }
        //foreign key Area
        [Display(Name = "Area")]
        [ForeignKey("Area_FId")]
        public  int Area_FId { get; set; }
        public virtual Area Area { get; set; }
       // foreign key Order
        [Display(Name = "Order")]

        [ForeignKey("Order_FId")]
        public  int Order_FId { get; set; }
        public virtual  Order Orders { get; set; }
    }
}