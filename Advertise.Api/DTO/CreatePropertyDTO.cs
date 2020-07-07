using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Advertise.Api.DTO
{
    public class CreatePropertyDTO
    {
        public string Description { get; set; }

        public double Price { get; set; }

        public double Deposit { get; set; }

        public string Lease { get; set; }

        public string Location { get; set; }

        public string Country { get; set; }

        public string County { get; set; }

        public string Town { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
    }
}