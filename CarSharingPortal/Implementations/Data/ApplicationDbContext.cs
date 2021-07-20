using CarSharingPortal.Models;
using CarSharingPortal.Models.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSharingPortal.Implementations.Data
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<CarSharingOffer> CarSharingOffers { get; set; }
        public DbSet<TravelRoute> TravelRoutes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CitiesTravelRoutes> CitiesTravelRoutes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.CarSharingOffers)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<City>()
                .HasMany(x => x.TravelRoutesStartingHere)
                .WithOne(x => x.Start)
                .HasForeignKey(x => x.StartId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<City>()
                .HasMany(x => x.TravelRoutesEndingHere)
                .WithOne(x => x.End)
                .HasForeignKey(x => x.EndId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}

