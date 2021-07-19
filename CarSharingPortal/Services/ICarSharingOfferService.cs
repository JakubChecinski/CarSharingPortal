using CarSharingPortal.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Services
{
    interface ICarSharingOfferService
    {
        IEnumerable<CarSharingOffer> Get();
        IEnumerable<CarSharingOffer> Get(string city1, string city2, bool isPassenger);
        void Add(CarSharingOffer offer);
        void Update(CarSharingOffer offer, string userId);
        void Delete(CarSharingOffer offer, string userId);
    }
}
