using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.ViewModel.CompanyViewModel
{
    public class UploadImageViewModel
    {
        public IFormFile CompanyLogo { get; set; }
    }
}
