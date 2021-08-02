using CarSharingPortal.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Services
{
    public interface ITravelRouteService
    {
        TravelRoute Get(int startId, int endId);
        void Add(TravelRoute route);
        bool CheckExistence(TravelRoute route);
    }
}
