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
       [Display(Name ="Area")]
       public virtual int Area_Id { get; set; }  
       [ForeignKey("AreaId")]
       public virtual Area Areas { get; set; }
      //foreign key Product To Area
      [Display(Name ="Product")]
      public virtual int Product_Fid { get; set; }

      [ForeignKey("ProductId")]
      public virtual Product Products { get; set; }
    }
}
