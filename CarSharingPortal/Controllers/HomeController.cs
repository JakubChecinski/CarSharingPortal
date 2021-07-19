using CarSharingPortal.Models;
using CarSharingPortal.Models.ViewModels;
using CarSharingPortal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICarSharingOfferService _offerService;
        private ICityService _cityService;

        public HomeController(ILogger<HomeController> logger, 
            ICarSharingOfferService offerService, ICityService cityService)
        {
            _logger = logger;
            _cityService = cityService;
            _offerService = offerService;
        }

        public IActionResult Index()
        {
            var vm = new IndexViewModel()
            {
                IsPassenger = true,
                Cities = _cityService.Get(),
                Offers = _offerService.Get(),
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
