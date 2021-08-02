using CarSharingPortal.Models;
using CarSharingPortal.Models.Domains;
using CarSharingPortal.Models.ViewModels;
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

        public IEnumerable<CarSharingOfferViewModel> Get()
        {
            return _unitOfWork.Offers.Get();
        }
        public IEnumerable<CarSharingOfferViewModel> Get(int city1Id, int city2Id, bool isPassenger)
        {
            return _unitOfWork.Offers.Get(city1Id, city2Id, isPassenger);
        }
        public IEnumerable<CarSharingOfferViewModel> Get(string authorName)
        {
            return _unitOfWork.Offers.Get(authorName);
        }
        public CarSharingOffer Get(int id)
        {
            return _unitOfWork.Offers.Get(id);
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
        public void Delete(int offerId, string userId)
        {
            _unitOfWork.Offers.Delete(offerId, userId);
            _unitOfWork.Save();
        }

    }
}
