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
        [Required]
        public String Name { get; set; }
        [Required]
        public String Type { get; set; }
        public DateTime Date_Time { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
