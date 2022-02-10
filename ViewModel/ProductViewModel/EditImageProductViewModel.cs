using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.ViewModel.ProductViewModel
{
    public class EditImageProductViewModel: UploadProductImageViewModel
    {
        public int Id { get; set; }
        public string ExistingImage { get; set; }
    }
}
