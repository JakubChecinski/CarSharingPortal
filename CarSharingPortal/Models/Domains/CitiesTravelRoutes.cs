using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Models.Domains
{
    public class CitiesTravelRoutes
    {
        // join table class
        // this is how EF core wants to represent many-to-many relationships, apparently

        [Key]
        public int Id { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int TravelRouteEndPointId { get; set; }
        public TravelRoute TravelRouteEndPoint { get; set; }
        public int TravelRouteConnectionId { get; set; }
        public TravelRoute TravelRouteConnection { get; set; }
    }
}
