using System;
using System.ComponentModel.DataAnnotations;
namespace ChainStoreSystem.ViewModel.CompanyViewModel
{
    public class CompanyDetailViewModel : EditImageViewModel
    {

        public String CompanyName { get; set; }

        public String CompanyEmail { get; set; }

        public String Address { get; set; }

        public String Message { get; set; }
    }
}
