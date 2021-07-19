using CarSharingPortal.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Models.Repositories
{
    interface ICarSharingOfferRepository
    {
        IEnumerable<CarSharingOffer> Get();
        IEnumerable<CarSharingOffer> Get(string city1, string city2, bool isPassenger);

    }
}
