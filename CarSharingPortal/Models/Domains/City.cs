using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Models.Domains
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<CitiesTravelRoutes> TravelRoutesIncluded { get; set; }
        public ICollection<TravelRoute> TravelRoutesStartingHere { get; set; }
        public ICollection<TravelRoute> TravelRoutesEndingHere { get; set; }

        public City()
        {
            TravelRoutesIncluded = new Collection<CitiesTravelRoutes>();
            TravelRoutesStartingHere = new Collection<TravelRoute>();
            TravelRoutesEndingHere = new Collection<TravelRoute>();
        }

    }
}
