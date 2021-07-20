using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Models.Domains
{
    public class TravelRoute
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="From")]
        public int StartId { get; set; }
        public City Start { get; set; }

        [Required]
        [Display(Name = "To")]
        public int EndId { get; set; }
        public City End { get; set; }

        public ICollection<CitiesTravelRoutes> AcceptableConnections { get; set; }
        public ICollection<CarSharingOffer> CarSharingOffers { get; set; }

        public TravelRoute()
        {
            AcceptableConnections = new Collection<CitiesTravelRoutes>();
            CarSharingOffers = new Collection<CarSharingOffer>();
        }

    }
}
