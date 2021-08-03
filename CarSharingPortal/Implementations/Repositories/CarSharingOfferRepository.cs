using CarSharingPortal.Models;
using CarSharingPortal.Models.Domains;
using CarSharingPortal.Models.Repositories;
using CarSharingPortal.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSharingPortal.Implementations.Repositories
{
    public class CarSharingOfferRepository : ICarSharingOfferRepository
    {
        private IApplicationDbContext _context;
        private ITravelRouteRepository _routes;
        public CarSharingOfferRepository(IApplicationDbContext context, ITravelRouteRepository Routes)
        {
            _context = context;
            _routes = Routes;
        }

        public IEnumerable<CarSharingOfferViewModel> Get()
        {
            var resultAsList = _context.CarSharingOffers
               .Include(x => x.TravelRoute)
               .Include(x => x.TravelRoute.Start)
               .Include(x => x.TravelRoute.End)
               .ToList();          // make LINQ agree with Entity
            return resultAsList
                .Select(x => new CarSharingOfferViewModel
                {
                    OfferId = x.Id,
                    From = x.TravelRoute.Start.Name,
                    To = x.TravelRoute.End.Name,
                    DateTravelStart = x.DateTravelStart,
                    IsAuthorPassenger = x.IsAuthorPassenger,
                    AuthorName = x.AuthorName,
                });
        }
        public IEnumerable<CarSharingOfferViewModel> Get(int city1Id, int city2Id, bool isPassenger)
        {
            var resultAsList = _context.CarSharingOffers
                // inequality because a passenger looks for drivers and vice versa
                .Where(x => x.IsAuthorPassenger != isPassenger) 
                .Include(x => x.TravelRoute)
                .Include(x => x.TravelRoute.Start)
                .Include(x => x.TravelRoute.End)
                .Include(x => x.TravelRoute.AcceptableConnections)
                .ThenInclude(y => y.City).ToList();
            resultAsList = resultAsList
                .Where(x => IsRouteAcceptable(x.TravelRoute, city1Id, city2Id)).ToList();
            return resultAsList
                .Select(x => new CarSharingOfferViewModel
                {
                    OfferId = x.Id,
                    From = x.TravelRoute.Start.Name,
                    To = x.TravelRoute.End.Name,
                    DateTravelStart = x.DateTravelStart,
                    IsAuthorPassenger = x.IsAuthorPassenger,
                    AuthorName = x.AuthorName,
                });
        }
        public IEnumerable<CarSharingOfferViewModel> Get(string authorName)
        {
            var resultAsList = _context.CarSharingOffers
                .Include(x => x.TravelRoute)
                .Include(x => x.TravelRoute.Start)
                .Include(x => x.TravelRoute.End)
                .Where(x => x.AuthorName == authorName).ToList();
            return resultAsList
                .Select(x => new CarSharingOfferViewModel
                {
                    OfferId = x.Id,
                    From = x.TravelRoute.Start.Name,
                    To = x.TravelRoute.End.Name,
                    DateTravelStart = x.DateTravelStart,
                    IsAuthorPassenger = x.IsAuthorPassenger,
                    AuthorName = x.AuthorName,
                });
        }
        public CarSharingOffer Get(int id)
        {
            return _context.CarSharingOffers
                .Include(x => x.TravelRoute)
                .Include(x => x.TravelRoute.Start)
                .Include(x => x.TravelRoute.End)
                .Single(x => x.Id == id);
        }

        private bool IsRouteAcceptable(TravelRoute tr, int city1Id, int city2Id)
        {
            var condition1 = tr.StartId == city1Id && tr.EndId == city2Id;
            var condition2 = tr.StartId == city1Id
                && tr.AcceptableConnections.Any(x => x.CityId == city2Id);
            var condition3 = tr.AcceptableConnections.Any(x => x.CityId == city1Id)
                && tr.End.Id == city2Id;
            var condition4 = tr.AcceptableConnections.Any(x => x.CityId == city1Id)
                && _routes.CheckConnection(city1Id, tr.EndId, city2Id);
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
        public void Delete(int offerId, string userId)
        {
            var offerToDelete = _context.CarSharingOffers.Single(x => x.Id == offerId && x.AuthorId == userId);
            _context.CarSharingOffers.Remove(offerToDelete);
        }

    }
}
