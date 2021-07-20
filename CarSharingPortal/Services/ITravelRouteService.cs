using CarSharingPortal.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Services
{
    public interface ITravelRouteService
    {
        TravelRoute Get(City start, City end);
        void Add(TravelRoute route);
    }
}
