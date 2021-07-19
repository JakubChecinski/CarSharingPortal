using CarSharingPortal.Models;
using CarSharingPortal.Models.Domains;
using CarSharingPortal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Implementations.Services
{
    public class CarSharingOfferService : ICarSharingOfferService
    {
        private IUnitOfWork _unitOfWork;
        public CarSharingOfferService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CarSharingOffer> Get()
        {
            return _unitOfWork.Offers.Get();
        }
        public IEnumerable<CarSharingOffer> Get(string city1, string city2, bool isPassenger)
        {
            return _unitOfWork.Offers.Get(city1, city2, isPassenger);
        }

        public void Add(CarSharingOffer offer)
        {
            _unitOfWork.Offers.Add(offer);
            _unitOfWork.Save();
        }
        public void Update(CarSharingOffer offer, string userId)
        {
            _unitOfWork.Offers.Update(offer, userId);
            _unitOfWork.Save();
        }
        public void Delete(CarSharingOffer offer, string userId)
        {
            _unitOfWork.Offers.Delete(offer, userId);
            _unitOfWork.Save();
        }

    }
}
