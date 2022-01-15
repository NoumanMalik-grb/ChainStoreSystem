using ChainStoreSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.ViewModel.ProductViewModel
{
    public class ProductImageViewModel : EditImageProductViewModel
    {
        [Required]
        public String ProductName { get; set; }
        [Required]
        public String Product_Discription_Max { get; set; }
        public String Product_Discription_Min { get; set; }
        [Required]
        public decimal Product_Sale_Price { get; set; }
        [Required]
        public decimal Product_Purchase_Price { get; set; }
        [Required]
        public String Product_Status { get; set; }
        public decimal Product_Discount { get; set; }
        [Required]
        public DateTime Product_Add_Date { get; set; }
        [Required]
        public DateTime Product_Exp_Date { get; set; }
        [Required]
        public int Sub_categoryId { get; set; }
        [Required]
        public int AreaId { get; set; }

        }
    }

