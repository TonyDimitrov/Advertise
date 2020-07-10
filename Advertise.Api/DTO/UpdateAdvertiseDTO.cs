using Advertise.Api.Constants;
using Advertise.Api.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertise.Api.DTO
{
    public class UpdateAdvertiseDTO
    {
        public int Id { get; set; }

        public AdvertiseType Type { get; set; }

        public Category Category { get; set; }

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

        [Required]
        public CreatePropertyDTO Property { get; set; }
    }
}
