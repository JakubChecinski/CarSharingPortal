using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        [DifferentThan("EndId")]
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

    public class DifferentThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;
        public DifferentThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }
        public string GetErrorMessage() =>
            $"From and to cities must be different";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (property == null) throw new ArgumentException("Property with this name not found");
            var comparisonValue = (int)property.GetValue(validationContext.ObjectInstance);
            if (comparisonValue != (int)value) return ValidationResult.Success;
            return new ValidationResult(GetErrorMessage());
        }
    }
}
