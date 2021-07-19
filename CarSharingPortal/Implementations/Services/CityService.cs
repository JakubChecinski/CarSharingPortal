using CarSharingPortal.Models;
using CarSharingPortal.Models.Domains;
using CarSharingPortal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Implementations.Services
{
    public class CityService : ICityService
    {
        private IUnitOfWork _unitOfWork;
        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<City> Get()
        {
            return _unitOfWork.Cities.Get();
        }
        public void Add(City city)
        {
            _unitOfWork.Cities.Add(city);
            _unitOfWork.Save();
        }

    }
}
