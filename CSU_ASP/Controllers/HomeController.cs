using CSU_ASP.Data;
using CSU_ASP.Data.interfaces;
using CSU_ASP.Data.Models;
using CSU_ASP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSU_ASP.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;

        private readonly ILogger<HomeController> _logger;

        public HomeController(IAllCars carRep, ILogger<HomeController> logger)
        {
            _carRep = carRep;
            _logger = logger;
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var homeCars = new HomeViewModel
                {
                    favCars = _carRep.getFavCars
                };
                return View(homeCars);
            }
            return View("Non_auth");
        }
    }
}
