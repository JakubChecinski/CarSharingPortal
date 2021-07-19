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

        // note: this collection will always have exactly two members (a start city and an end city)
        // why isn't it implemented as two City class properties?
        // because it caused problematic behavior while deleting a city:
        // we want to delete the travel route if either start or end point gets deleted (doesn't matter which one)
        // but EF disallows that because it fears "cycles or multiple cascade paths"
        // another disadvantage was that we don't really care about which city is the start point and which is the end point
        // since our connection graph is always symmetrical (model assumption)
        public ICollection<CitiesTravelRoutes> StartOrEndPoints { get; set; }
        public ICollection<CitiesTravelRoutes> AcceptableConnections { get; set; }
        public ICollection<CarSharingOffer> CarSharingOffers { get; set; }

        public TravelRoute()
        {
            StartOrEndPoints = new Collection<CitiesTravelRoutes>();
            AcceptableConnections = new Collection<CitiesTravelRoutes>();
            CarSharingOffers = new Collection<CarSharingOffer>();
        }

    }
}
