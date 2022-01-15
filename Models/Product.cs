using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String ProductName { get; set; }
        [Required]
        public String Product_Picture { get; set; }
        [Required]
        public String Product_Discription_Max { get; set; }       
        public String Product_Discription_Min { get; set; }
        [Required]
        public decimal Product_Sale_Price { get; set; }
        [Required]
        public decimal Product_Purchase_Price { get; set; }
        [Required]
        public String Product_Status { get; set; }       
        public decimal Product_Discount { get; set; }
        [Required]
        public DateTime Product_Add_Date { get; set; }
        [Required]
        public DateTime Product_Exp_Date { get; set; }
        //foreign key SubCategry
        [Display(Name ="SubCategory")]
        [ForeignKey("SubCategory_FId")]
        public int SubCategory_Fid { get; set; }        
        public virtual SubCategory SubCategorys { get; set; }
        //foreign key Area
        [Display(Name = "Area")]
        [ForeignKey("Area_FId")]
        public int Area_FId { get; set; }
        public virtual Area Areas { get; set; }
        
    }
}