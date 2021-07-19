using CarSharingPortal.Models;
using CarSharingPortal.Models.Domains;
using CarSharingPortal.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Implementations.Repositories
{
    public class CityRepository : ICityRepository
    {
        private IApplicationDbContext _context;
        public CityRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<City> Get()
        {
            return _context.Cities;
        }
        public void Add(City city)
        {
            _context.Cities.Add(city);
        }
    }
}
