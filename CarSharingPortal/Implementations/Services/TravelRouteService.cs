using CarSharingPortal.Models;
using CarSharingPortal.Models.Domains;
using CarSharingPortal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Implementations.Services
{
    public class TravelRouteService : ITravelRouteService
    {
        private IUnitOfWork _unitOfWork;
        public TravelRouteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TravelRoute Get(int startId, int endId)
        {
            return _unitOfWork.Routes.Get(startId, endId);
        }
        public void Add(TravelRoute route)
        {
            if(!CheckExistence(route))
            {
                _unitOfWork.Routes.Add(route);
                _unitOfWork.Save();
            }
        }
        public bool CheckExistence(TravelRoute route)
        {
            if (_unitOfWork.Routes.Get(route.StartId, route.EndId) == null) return false;
            else return true;
        }

    }
}
