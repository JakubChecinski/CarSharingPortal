using CarSharingPortal.Models.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<CarSharingOfferViewModel> Offers { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public bool IsPassenger { get; set; }

        public int SearchingFromId { get; set; }

        public int SearchingToId { get; set; }
    }
}
