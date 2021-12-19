using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Models
{
    public class Category
    {
        [Key]
        public int  Id{ get; set; }
        [Required]
        public String CategoryName { get; set; }
        [Required]
        public String CategoryStatus { get; set; }
    }
}
