using CarSharingPortal.Models.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Models
{
    public interface IApplicationDbContext
    {
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<CarSharingOffer> CarSharingOffers { get; set; }
        DbSet<TravelRoute> TravelRoutes { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<CitiesTravelRoutes> CitiesTravelRoutes { get; set; }
        int SaveChanges();
    }
}
