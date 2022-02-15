using ChainStoreSystem.Data;
using ChainStoreSystem.Helpers;
using ChainStoreSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Controllers
{
    public class CartController : Controller
    {
        private readonly ChainStoreDbContext _context;
        public CartController(ChainStoreDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult MenuCart()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTOCart(int id)
        {
            List<Product> listcart;
            if (SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "listcart")==null)
            {
                listcart=  new List<Product>();
            }
            else
            {
                listcart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "listcart");
            }
            Boolean isProductExist = false;
            foreach (var item in listcart)
            {

                if (id == item.Id)
                {
                    isProductExist = true;
                    item.Product_Quantity++;
                }
            }

            if (isProductExist == false)
            {
                listcart.Add(_context.products.Where(p => p.Id == id).FirstOrDefault());
                listcart[listcart.Count - 1].Product_Quantity = 1;
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Plistcart", listcart);      
            return View("MenuCart");
        }
       // for Plus Quantity
        public IActionResult Plus(int RowNo)
        {
            List<Product> listCart;
            listCart= SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "Plistcart");
            int P_Id = listCart[RowNo].Id;
            listCart[RowNo].Product_Quantity++;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Plistcart", listCart);
            return RedirectToAction("MenuCart");
        }
        //for minus Quantity
        public IActionResult Minus(int RowNo)
        {
            List<Product> listCart;
            listCart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "Plistcart");
            listCart[RowNo].Product_Quantity--;
            if (listCart[RowNo].Product_Quantity==0)
            {
                listCart.RemoveAt(RowNo);
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Plistcart", listCart);
            return RedirectToAction("MenuCart");
        }
        //for remove quantity
        public IActionResult Remove(int RowNo)
        {
            List<Product> listCart;
            listCart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "Plistcart");
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Plistcart", listCart);
            listCart.RemoveAt(RowNo);
            return RedirectToAction("MenuCart");
        }
        //Order from customer
        [HttpGet]
        public IActionResult OrderCustomer()
        {
            return View();
        }
        public IActionResult PayNo(Order o)
        {
            o.Order_Type = "sale";
            o.Order_Delivery_Status = "pending";
            o.Id = o.Product_Fid;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "odersession", o);
            if (o.Order_Status=="Offline")
            {
                o.Order_Status = "Offline";
            }
            _context.orders.Add(o);
            _context.SaveChanges();
            List<Product> p;
            p = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "Plistcart");
            for (int i = 0; i < p.Count; i++)
            {
                OrderDetail od = new OrderDetail();
                int orderid = _context.orders.Max(x => x.Id);
                od.Order_FId = orderid;
                od.Product_FId = p[i].Id;
                od.Area_FId = p[i].Id;
                od.Quantity = p[i].Product_Quantity * -1;
                od.Sale_Price = Convert.ToDecimal(p[i].Product_Sale_Price);
                od.Purchase_Price = Convert.ToDecimal(p[i].Product_Purchase_Price);
                _context.orderDetails.Add(od);
                _context.SaveChanges();
                //session null  of product Now
               
            }
            return RedirectToAction("Index", "Customer");
        }
    }
}
