using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Models.Domains
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<CarSharingOffer> CarSharingOffers { get; set; }
        public ApplicationUser()
        {
            CarSharingOffers = new Collection<CarSharingOffer>();
        }
    }
}
