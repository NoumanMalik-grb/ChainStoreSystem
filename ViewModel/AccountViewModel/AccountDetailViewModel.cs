using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.ViewModel.AccountViewModel
{
    public class AccountDetailViewModel : EditViewAccountModel
    {
        public string UserName { get; set; }

        public String UserEmail { get; set; }

        public String UserMobile { get; set; }

        public String Address1 { get; set; }

        public String Address2 { get; set; }

        public String CNIC { get; set; }

        public DateTime Date_Time { get; set; }

        public String PassWord { get; set; }

        public String Type { get; set; }

    }
}
