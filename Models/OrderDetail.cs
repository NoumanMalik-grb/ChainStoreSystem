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
        public String Quantity { get; set; }
        //foreign key Prodcut
        [Display(Name ="Product")]
        public virtual int Product_Fid { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Products { get; set; }
        //foreign key Area
        [Display(Name = "Area")]
        public virtual int Area_Fid { get; set; }

        [ForeignKey("AreaId")]
        public virtual Area Area { get; set; }
        //foreign key Order
        [Display(Name = "Order")]
        public virtual int Order_Fid { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Orders { get; set; }
    }
}