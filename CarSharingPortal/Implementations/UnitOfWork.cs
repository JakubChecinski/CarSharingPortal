using CarSharingPortal.Implementations.Repositories;
using CarSharingPortal.Models;
using CarSharingPortal.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;
        public ICarSharingOfferRepository Offers { get; }
        public ICityRepository Cities { get; }

        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
            Offers = new CarSharingOfferRepository(context);
            Cities = new CityRepository(context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
