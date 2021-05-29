using CSU_ASP.Data;
using CSU_ASP.Data.interfaces;
using CSU_ASP.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CSU_ASP.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        [AllowAnonymous]
        public IActionResult Checkout()
        {
            if (User.Identity.IsAuthenticated)
                return View();

            return View("Non_auth");
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.shopItems = shopCart.GetShopItems();

            if(shopCart.shopItems.Count == 0)
            {
                return RedirectToAction("EmptyCart");
            }

            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }

        public IActionResult EmptyCart()
        {
            return View();
        }
    }
}
