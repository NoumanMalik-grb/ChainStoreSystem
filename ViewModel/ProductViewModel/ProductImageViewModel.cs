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

        public String ProductName { get; set; }

        public String Product_Discription_Max { get; set; }
        public String Product_Discription_Min { get; set; }

        public decimal Product_Sale_Price { get; set; }

        public decimal Product_Purchase_Price { get; set; }

        public String Product_Status { get; set; }
        public decimal Product_Discount { get; set; }

        public DateTime Product_Add_Date { get; set; }

        public DateTime Product_Exp_Date { get; set; }

        public int Sub_categoryId { get; set; }

        public int AreaId { get; set; }

    }
}

