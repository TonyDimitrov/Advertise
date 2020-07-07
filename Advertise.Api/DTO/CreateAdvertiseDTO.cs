using Advertise.Api.Data.Models.Enums;
using System;
using System.Collections.Generic;

namespace Advertise.Api.DTO
{
    public class CreateAdvertiseDTO
    {
        public AdvertiseType Type { get; set; }

        public Category Category { get; set; }

        public string Title { get; set; }

        public string ContactPerson { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }

        public CreatePropertyDTO Property { get; set; }
    }
}
