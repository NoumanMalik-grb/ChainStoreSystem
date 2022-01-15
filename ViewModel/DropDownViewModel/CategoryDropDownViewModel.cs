using ChainStoreSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.ViewModel.DropDownViewModel
{
    public class CategoryDropDownViewModel
    {
        [Required]
        public String SubCategoryName { get; set; }
        [Required]
        public String SubCategoryStatus { get; set; }       
        public int CategoryId { get; set; }
        
    }
}
