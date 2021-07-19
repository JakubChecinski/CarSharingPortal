using CarSharingPortal.Models;
using CarSharingPortal.Models.Domains;
using CarSharingPortal.Models.Repositories;
using CarSharingPortal.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Implementations.Repositories
{
    public class CarSharingOfferRepository : ICarSharingOfferRepository
    {
        private IApplicationDbContext _context;
        public CarSharingOfferRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CarSharingOfferViewModel> Get()
        {
            var resultAsList = _context.CarSharingOffers
                .Include(x => x.Author).ToList();           // make LINQ agree with Entity
            return resultAsList
                .Select(x => new CarSharingOfferViewModel
                {
                    From = x.TravelRoute.StartOrEndPoints.Count > 0 ? null 
                        : x.TravelRoute.StartOrEndPoints.ElementAt(0).City.Name,
                    To = x.TravelRoute.StartOrEndPoints.Count > 0 ? null
                        : x.TravelRoute.StartOrEndPoints.ElementAt(1).City.Name,
                    DateTravelStart = x.DateTravelStart,
                    IsAuthorPassenger = x.IsAuthorPassenger,
                    AuthorName = x.Author.UserName,
                    AuthorEmail = x.Author.Email,
                });
        }
        public IEnumerable<CarSharingOfferViewModel> Get(string city1, string city2, bool isPassenger)
        {
            var resultAsList = _context.CarSharingOffers
                .Include(x => x.Author.UserName)
                .Include(x => x.Author.Email)
                .Where(x => x.IsAuthorPassenger == isPassenger)
                .Where(x => IsRouteAcceptable(x.TravelRoute, city1, city2)).ToList();
            return resultAsList
                .Select(x => new CarSharingOfferViewModel
                {
                    From = x.TravelRoute.StartOrEndPoints.Count > 0 ? null 
                        : x.TravelRoute.StartOrEndPoints.ElementAt(0).City.Name,
                    To = x.TravelRoute.StartOrEndPoints.Count > 0 ? null
                        : x.TravelRoute.StartOrEndPoints.ElementAt(1).City.Name,
                    DateTravelStart = x.DateTravelStart,
                    IsAuthorPassenger = x.IsAuthorPassenger,
                    AuthorName = x.Author.UserName,
                    AuthorEmail = x.Author.Email,
                });
        }
        private bool IsRouteAcceptable(TravelRoute tr, string city1, string city2)
        {
            var condition1 = tr.StartOrEndPoints.Any(x => x.City.Name == city1)
                && tr.StartOrEndPoints.Any(x => x.City.Name == city2);
            var condition2 = tr.StartOrEndPoints.Any(x => x.City.Name == city1)
                && tr.AcceptableConnections.Any(x => x.City.Name == city2);
            var condition3 = tr.AcceptableConnections.Any(x => x.City.Name == city1)
                && tr.StartOrEndPoints.Any(x => x.City.Name == city2);
            var condition4 = tr.AcceptableConnections.Any(x => x.City.Name == city1)
                && tr.AcceptableConnections.Any(x => x.City.Name == city2);
            return condition1 || condition2 || condition3 || condition4;
        }

        public void Add(CarSharingOffer offer)
        {
            _context.CarSharingOffers.Add(offer);
        }
        public void Update(CarSharingOffer offer, string userId)
        {
            var offerToUpdate = _context.CarSharingOffers.Single(x => x.Id == offer.Id && x.AuthorId == userId);
            offerToUpdate.AuthorId = offer.AuthorId;
            offerToUpdate.DateTravelStart = offer.DateTravelStart;
            offerToUpdate.IsAuthorPassenger = offer.IsAuthorPassenger;
            offerToUpdate.TravelRouteId = offer.TravelRouteId;
        }
        public void Delete(CarSharingOffer offer, string userId)
        {
            var offerToDelete = _context.CarSharingOffers.Single(x => x.Id == offer.Id && x.AuthorId == userId);
            _context.CarSharingOffers.Remove(offerToDelete);
        }

    }
}
