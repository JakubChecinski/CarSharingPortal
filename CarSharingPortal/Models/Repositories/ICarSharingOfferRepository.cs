using CarSharingPortal.Models.Domains;
using CarSharingPortal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Models.Repositories
{
    public interface ICarSharingOfferRepository
    {
        IEnumerable<CarSharingOfferViewModel> Get();
        IEnumerable<CarSharingOfferViewModel> Get(string city1, string city2, bool isPassenger);
        void Add(CarSharingOffer offer);
        void Update(CarSharingOffer offer, string userId);
        void Delete(CarSharingOffer offer, string userId);

    }
}
