using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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

        public DateTime DateCreated { get; set; }

        [Required]
        [GreaterThanToday]
        [Display(Name="Travelling on...")]
        public DateTime DateTravelStart { get; set; }

        [Required]
        public bool IsAuthorPassenger { get; set; }

        public string AuthorName { get; set; }


        [Required]
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }


        public int TravelRouteId { get; set; }
        public TravelRoute TravelRoute { get; set; }
    }

    public class GreaterThanTodayAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
            $"Travel date must be today or later";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((DateTime)value >= DateTime.Today) return ValidationResult.Success;
            return new ValidationResult(GetErrorMessage());
        }
    }

}
