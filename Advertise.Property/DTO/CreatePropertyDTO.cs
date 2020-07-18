using Advertise.Property.Constants;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Advertise.Property.DTO
{
    public class CreatePropertyDTO
    {
        [MaxLength(ValidationConstants.PropertyDescriptionMaxLen)]
        [MinLength(ValidationConstants.PropertyDescriptionMinLen)]
        public string Description { get; set; }

        [Range(ValidationConstants.PropertyPriceMinLen, ValidationConstants.PropertyPriceMaxLen)]
        public double Price { get; set; }

        [Range(ValidationConstants.PropertyDepositMinLen, ValidationConstants.PropertyDepositMaxLen)]
        public double Deposit { get; set; }

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

        [JsonIgnore]
        public IEnumerable<IFormFile> Images { get; set; }
    }
}