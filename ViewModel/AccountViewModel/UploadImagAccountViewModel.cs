using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.ViewModel.AccountViewModel
{
    public class UploadImagAccountViewModel
    {
        [Required]
        [Display(Name ="Image")]
        public IFormFile User_Picture { get; set; }
    }
}
