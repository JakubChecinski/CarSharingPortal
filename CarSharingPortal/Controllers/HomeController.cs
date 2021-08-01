using CarSharingPortal.Implementations.Extensions;
using CarSharingPortal.Models;
using CarSharingPortal.Models.Domains;
using CarSharingPortal.Models.ViewModels;
using CarSharingPortal.Services;
using Microsoft.AspNetCore.Authorization;
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
        private ITravelRouteService _routeService;

        public HomeController(ILogger<HomeController> logger, 
            ICarSharingOfferService offerService, ICityService cityService, ITravelRouteService routeService)
        {
            _logger = logger;
            _cityService = cityService;
            _offerService = offerService;
            _routeService = routeService;
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

        [HttpGet]
        [Authorize]
        public IActionResult AddEditOffer()
        {
            var userId = User.GetUserId();
            var vm = new AddEditOfferViewModel
            {
                Heading = "Add a new offer",
                Cities = _cityService.Get().ToList(),
                Offer = new CarSharingOffer()
                {
                    AuthorId = userId,
                    DateCreated = DateTime.Today,
                    DateTravelStart = DateTime.Today.AddDays(1),
                },
                Route = new TravelRoute(),
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEditOffer(AddEditOfferViewModel vm)
        {
            var userId = User.GetUserId();
            vm.Offer.AuthorId = userId;
            if (!ModelState.IsValid)
            {
                var newVm = new AddEditOfferViewModel
                {
                    Heading = "Add a new offer",
                    Cities = _cityService.Get().ToList(),
                    Offer = new CarSharingOffer()
                    {
                        AuthorId = userId,
                        DateCreated = DateTime.Today,
                        DateTravelStart = DateTime.Today.AddDays(1),
                    },
                    Route = new TravelRoute(),
                };
                return View("AddEditOffer", newVm);
            }
            _routeService.Add(vm.Route);
            vm.Offer.TravelRoute = vm.Route;
            vm.Offer.AuthorName = User.GetUserName();
            _offerService.Add(vm.Offer);
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Authorize]
        public IActionResult Manage()
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
