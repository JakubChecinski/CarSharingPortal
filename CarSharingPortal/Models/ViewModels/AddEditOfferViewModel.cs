using CarSharingPortal.Models.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Models.ViewModels
{
    public class AddEditOfferViewModel
    {
        public CarSharingOffer Offer { get; set; }
        public List<City> Cities { get; set; }
        public string Heading { get; set; }
        public bool IsAdd { get; set; }
        public TravelRoute Route { get; set; }
    }
}
