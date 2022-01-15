using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.ViewModel.AccountViewModel
{
    public class EditViewAccountModel: UploadImagAccountViewModel
    {
        public int Id { get; set; }
        public string ExistingImage { get; set; }
    }
}
