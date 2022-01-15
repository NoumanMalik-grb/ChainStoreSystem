using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.ViewModel.AccountViewModel
{
    public class AccountDetailViewModel: EditViewAccountModel
    {
        public string UserName { get; set; }
        [Required]
        public String UserEmail { get; set; }
        [Required]
        public String UserMobile { get; set; }
        [Required]
        public String Address1 { get; set; }
        [Required]
        public String Address2 { get; set; }
        [Required]
        public String CNIC { get; set; }        
        [Required]
        public DateTime Date_Time { get; set; }
        [Required]
        public String PassWord { get; set; }
        [Required]
        public String Type { get; set; }

    }
}
