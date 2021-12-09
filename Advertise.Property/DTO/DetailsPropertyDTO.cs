using Advertise.Property.Data.Models.Enums;
using System;
using System.Collections.Generic;

namespace Advertise.Property.DTO
{
    public class DetailsPropertyDTO
    {
        public string Description { get; set; }

        public double Price { get; set; }

        public double? Deposit { get; set; }

        public string Lease { get; set; }

        public double DiscountedPrice { get; set; }

        public string Location { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }


        public Category Category { get; set; }

        public string Title { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string ContactPerson { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }

        public int PropertyId { get; set; }

        public HashSet<string> Images { get; set; }
    }
}
