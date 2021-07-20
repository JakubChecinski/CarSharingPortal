using CarSharingPortal.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Models.Repositories
{
    public interface ITravelRouteRepository
    {
        TravelRoute Get(City start, City end);
        void Add(TravelRoute route);
    }
}
