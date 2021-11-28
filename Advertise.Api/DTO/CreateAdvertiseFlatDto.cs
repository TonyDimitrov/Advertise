using Advertise.Api.Constants;
using Advertise.Api.Data.Models.Enums;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Api.DTO
{
    public class CreateAdvertiseFlatDto
    {
        public AdvertiseType Type { get; set; }

        public Category Category { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }


        [MaxLength(ValidationConstants.AdTitleMaxLen)]
        [MinLength(ValidationConstants.AdTitleMinLen)]
        [Required]
        public string Title { get; set; }

        [MaxLength(ValidationConstants.AdContactPersonMaxLen)]
        [MinLength(ValidationConstants.AdContactPersonMinLen)]
        [Required]
        public string ContactPerson { get; set; }

        [MaxLength(ValidationConstants.AdContactPhoneMaxLen)]
        [MinLength(ValidationConstants.AdContactPhoneMinLen)]
        public string ContactPhone { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [MaxLength(ValidationConstants.PropertyDescriptionMaxLen)]
        [MinLength(ValidationConstants.PropertyDescriptionMinLen)]
        public string Description { get; set; }

        [Range(ValidationConstants.PropertyPriceMinLen, ValidationConstants.PropertyPriceMaxLen)]
        public double Price { get; set; }

        [Range(ValidationConstants.PropertyDepositMinLen, ValidationConstants.PropertyDepositMaxLen)]
        public double? Deposit { get; set; }

        [MaxLength(ValidationConstants.PropertyLeaseMaxLen)]
        [MinLength(ValidationConstants.PropertyDepositMinLen)]
        public string Lease { get; set; }

        [MaxLength(ValidationConstants.PropertyLocationMaxLen)]
        [MinLength(ValidationConstants.PropertyLocationMinLen)]
        public string Location { get; set; }

        [MaxLength(ValidationConstants.PropertyCountyMaxLen)]
        [MinLength(ValidationConstants.PropertyCountyMinLen)]
        public string Country { get; set; }

        [MaxLength(ValidationConstants.PropertyTownMaxLen)]
        [MinLength(ValidationConstants.PropertyTownMinLen)]
        public string Town { get; set; }
    }
}
