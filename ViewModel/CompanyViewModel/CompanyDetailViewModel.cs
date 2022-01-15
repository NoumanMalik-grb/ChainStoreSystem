using System;
using System.ComponentModel.DataAnnotations;
namespace ChainStoreSystem.ViewModel.CompanyViewModel
{
    public class CompanyDetailViewModel: EditImageViewModel
    {
        [Required]
        public String CompanyName { get; set; }
        [Required]
        public String CompanyEmail { get; set; }
        [Required]
        public String Address { get; set; }
        [Required]
        public String Message { get; set; }
    }
}
