using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Models
{
    public class DamagedProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Type { get; set; }
        public DateTime Date_Time { get; set; }
        //foreign key Area
        [Display(Name = "Area")]
        [ForeignKey("Area_FId")]
        public int Area_FId { get; set; }
        public virtual Area Areas { get; set; }
        //foreign key Product To Area
        [Display(Name = "Product")]
        [ForeignKey("Product_Fid")]
        public int Product_Fid { get; set; }
        public virtual Product Products { get; set; }
    }
}
