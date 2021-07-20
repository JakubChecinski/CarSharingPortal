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

        public TravelRoute Get(City start, City end)
        {
            return _unitOfWork.Routes.Get(start, end);
        }
        public void Add(TravelRoute route)
        {
            _unitOfWork.Routes.Add(route);
            _unitOfWork.Save();
        }


    }
}
