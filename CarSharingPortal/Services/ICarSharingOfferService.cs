using CarSharingPortal.Models.Domains;
using CarSharingPortal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Services
{
    public interface ICarSharingOfferService
    {
        IEnumerable<CarSharingOfferViewModel> Get(); 
        IEnumerable<CarSharingOfferViewModel> Get(int city1Id, int city2Id, bool isPassenger);
        IEnumerable<CarSharingOfferViewModel> Get(string authorName);
        CarSharingOffer Get(int id);
        void Add(CarSharingOffer offer);
        void Update(CarSharingOffer offer, string userId);
        void Delete(int offerId, string userId);
    }
}
