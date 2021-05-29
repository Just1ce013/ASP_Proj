using CSU_ASP.Data;
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
    public class CarsController : Controller
    {

        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars allCars, ICarsCategory carsCategory)
        {
            _allCars = allCars;
            _allCategories = carsCategory;
        }

        [AllowAnonymous]
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            if(User.Identity.IsAuthenticated)
            {
                string _category = category;
                IEnumerable<Car> cars = null;
                string currCategory = "";
                if (string.IsNullOrEmpty(category))
                {
                    cars = _allCars.Cars.OrderBy(i => i.id);
                }
                else
                {
                    if (string.Equals("electro", _category, StringComparison.OrdinalIgnoreCase))
                    {
                        cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Электромобили")).OrderBy(i => i.id);
                        currCategory = "Электромобили";
                    }
                    else if (string.Equals("fuel", _category, StringComparison.OrdinalIgnoreCase))
                    {
                        cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Машины с ДВС")).OrderBy(i => i.id);
                        currCategory = "Машины с ДВС";
                    }
                }

                var carObj = new CarsListViewModel()
                {
                    allCars = cars,
                    currCategory = currCategory
                };

                ViewBag.Title = "Страница с автомобилями";


                return View(carObj);
            }

            return View("Non_auth");
        }
    }
}
