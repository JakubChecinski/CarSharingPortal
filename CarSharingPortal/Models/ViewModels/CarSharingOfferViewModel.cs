using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharingPortal.Models.ViewModels
{
    public class CarSharingOfferViewModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DateTravelStart { get; set; }
        public bool IsAuthorPassenger { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }

    }
}
