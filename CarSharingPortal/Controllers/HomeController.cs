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

        [HttpPost]
        public IActionResult Index(IndexViewModel viewModel)
        {
            var validOffers = _offerService.Get(viewModel.SearchingFromId, 
                viewModel.SearchingToId, viewModel.IsPassenger);
            return PartialView("_OffersTable", validOffers);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddEditOffer(int id = 0)
        {
            return View(PrepareViewModel(id, id == 0));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEditOffer(AddEditOfferViewModel vm)
        {
            if (!ModelState.IsValid) return View("AddEditOffer", PrepareViewModel(vm.Offer.Id, vm.IsAdd));
            vm.Offer.AuthorId = User.GetUserId();
            vm.Offer.AuthorName = User.GetUserName();
            vm.Offer.TravelRouteId = GetUniqueRouteId(vm.Route);
            if (vm.IsAdd)
            {
                _offerService.Add(vm.Offer);
                return RedirectToAction("Index");
            }
            else
            {
                _offerService.Update(vm.Offer, User.GetUserId());
                return RedirectToAction("ManageOffers");
            }
        }
        private int GetUniqueRouteId(TravelRoute route)
        {
            if (_routeService.CheckExistence(route))
            {
                return _routeService.Get(route.StartId, route.EndId).Id;
            }
            var newRoute = new TravelRoute()
            {
                StartId = route.StartId,
                EndId = route.EndId,
            };
            _routeService.Add(newRoute);
            return newRoute.Id;
        }
        private AddEditOfferViewModel PrepareViewModel(int offerId, bool isAdd)
        {
            var userId = User.GetUserId();
            var offer = isAdd ?
                new CarSharingOffer()
                {
                    AuthorId = userId,
                    DateCreated = DateTime.Today,
                    DateTravelStart = DateTime.Today.AddDays(1),
                } :
                _offerService.Get(offerId);
            return new AddEditOfferViewModel
            {
                IsAdd = isAdd,
                Heading = isAdd ? "Add a new offer" : "Edit offer",
                Cities = _cityService.Get().ToList(),
                Offer = offer,
                Route = isAdd ? new TravelRoute() :
                _routeService.Get(offer.TravelRoute.StartId, offer.TravelRoute.EndId),
            };
        }


        [HttpGet]
        [Authorize]
        public IActionResult ManageOffers()
        {
            var offers = _offerService.Get(User.GetUserName());
            return View(offers);
        }

        [HttpPost]
        public IActionResult DeleteOffer(int id)
        {
            var userId = User.GetUserId();
            try
            {
                _offerService.Delete(id, userId);
            }
            catch (Exception exc)
            {
                // logowanie bledu
                return Json(new
                {
                    success = false,
                    message = exc.Message
                });
            }
            return Json(new { success = true });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
