using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.ViewModel.DamagedProduct
{
    public class DamagedProductViewModel
    {
        [Key]
        public int Id { get; set; }
       
        public String Name { get; set; }
       
        public String Type { get; set; }
        public DateTime Date_Time { get; set; }
       
        public int AreaId { get; set; }
       
        public int ProductId { get; set; }
    }
}
