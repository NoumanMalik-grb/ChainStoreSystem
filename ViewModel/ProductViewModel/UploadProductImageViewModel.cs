using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.ViewModel.ProductViewModel
{
    public class UploadProductImageViewModel
    {
        [Required]
        [Display(Name ="Image")]
        public IFormFile Product_Picture { get; set; }
    }
}
