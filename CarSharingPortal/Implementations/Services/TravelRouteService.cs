using CarSharingPortal.Models;
using CarSharingPortal.Models.Domains;
using CarSharingPortal.Services;
using ShortestPathCalculator;
using System.Collections.Generic;
using System.Linq;

namespace CarSharingPortal.Implementations.Services
{
    public class TravelRouteService : ITravelRouteService
    {
        private IUnitOfWork _unitOfWork;
        private Graph _connectionGraph;
        private IEnumerable<City> _cities;
        public TravelRouteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _cities = _unitOfWork.Cities.Get();
            _connectionGraph = new Graph();
        }

        public TravelRoute Get(int startId, int endId)
        {
            return _unitOfWork.Routes.Get(startId, endId);
        }
        public void Add(TravelRoute route)
        {
            if (CheckExistence(route)) return;
            var namesOfAcceptableCities = _connectionGraph.FindShortest(
                _cities.Single(x => x.Id == route.StartId).Name,
                _cities.Single(x => x.Id == route.EndId).Name);
            foreach(var cityName in namesOfAcceptableCities)
            {
                route.AcceptableConnections.Add(new CitiesTravelRoutes()
                { 
                    TravelRouteId = route.Id,
                    CityId = _cities.Single(x => x.Name == cityName).Id,
                });
            }
            _unitOfWork.Routes.Add(route);
            _unitOfWork.Save();
            // add subroutes as separate objects
            // note that the original route must be committed first, or we would risk an infinite recurrency
            foreach (var cityName in namesOfAcceptableCities)
            {
                Add(new TravelRoute()
                {
                    StartId = route.StartId,
                    EndId = _cities.Single(x => x.Name == cityName).Id,
                });
                Add(new TravelRoute()
                {
                    StartId = _cities.Single(x => x.Name == cityName).Id,
                    EndId = route.EndId,
                });
            }
        }
        public bool CheckExistence(TravelRoute route)
        {
            if (_unitOfWork.Routes.Get(route.StartId, route.EndId) == null) return false;
            else return true;
        }

    }
}
