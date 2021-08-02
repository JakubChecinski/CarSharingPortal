using CarSharingPortal.Models;
using CarSharingPortal.Models.Domains;
using CarSharingPortal.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarSharingPortal.Implementations.Repositories
{
    public class TravelRouteRepository : ITravelRouteRepository
    {
        private IApplicationDbContext _context;
        public TravelRouteRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(TravelRoute route)
        {
            _context.TravelRoutes.Add(route);
        } 

        public TravelRoute Get(int startId, int endId)
        {
            return _context.TravelRoutes.SingleOrDefault(x => x.StartId == startId && x.EndId == endId);
        }
        public bool CheckConnection(int startId, int endId, int connectionId)
        {
            var route = _context.TravelRoutes
                .Include(x => x.AcceptableConnections).ThenInclude(y => y.City)
                .SingleOrDefault(x => x.StartId == startId && x.EndId == endId);
            if (route == null) return false;
            else if (route.AcceptableConnections.Any(x => x.CityId == connectionId)) return true;
            else return false;
        }
    }
}
