using CarSharingPortal.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Models.Repositories
{
    public interface ITravelRouteRepository
    {
        TravelRoute Get(int startId, int endId);
        void Add(TravelRoute route);
    }
}
