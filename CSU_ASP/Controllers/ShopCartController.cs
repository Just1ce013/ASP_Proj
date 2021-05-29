using CSU_ASP.Data.interfaces;
using CSU_ASP.Data.Models;
using CSU_ASP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSU_ASP.Controllers
{
    [Authorize]
    public class ShopCartController : Controller
    {

        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;


        public ShopCartController(IAllCars carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        [AllowAnonymous]
        public ViewResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                var items = _shopCart.GetShopItems();
                _shopCart.shopItems = items;

                var obj = new ShopCartViewModel
                {
                    shopCart = _shopCart
                };
                return View(obj);
            }

            return View("Non_auth");
        }

        public RedirectToActionResult addToCart(int ID)
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.id == ID);
            if (item != null)
                _shopCart.AddToCart(item);
            return RedirectToAction("Index");
        }
    }
}
