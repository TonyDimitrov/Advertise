﻿using Advertise.Api.Constants;
using Advertise.Api.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Api.DTO
{
    public class CreateAdvertiseDTO
    {
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
