using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Models.Domains
{
    public class CarSharingOffer
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime DateTravelStart { get; set; }

        [Required]
        public bool IsAuthorPassenger { get; set; }


        [Required]
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }


        [Required]
        public int TravelRouteId { get; set; }
        public TravelRoute TravelRoute { get; set; }
    }
}
