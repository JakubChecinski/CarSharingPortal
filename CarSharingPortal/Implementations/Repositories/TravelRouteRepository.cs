using CarSharingPortal.Models;
using CarSharingPortal.Models.Domains;
using CarSharingPortal.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
