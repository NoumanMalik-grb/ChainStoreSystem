using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String SubCategoryName { get; set; }
        [Required]
        public String SubCategoryStatus { get; set; }
        //foreign key
        [Display(Name ="Category")]
        [ForeignKey("Category_Fid")]
        public int Category_Fid { get; set; }
        public virtual Category Category  { get; set; }
    }
}
