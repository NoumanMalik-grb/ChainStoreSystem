using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Models
{
    public class CompanyDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String CompanyName { get; set; }
        [Required]
        public String CompanyEmail { get; set; }
        [Required]
        public String CompanyLogo { get; set; }
        [Required]
        public String Address { get; set; }
        [Required]    
        public String Message { get; set; }
    }
}
