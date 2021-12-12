using Advertise.Property.Data.Models.Enums;
using System;

namespace Advertise.Property.Data.Models
{
    public class Advertise : BaseModel
    {
        public AdvertiseType? Type { get; set; }

        public Category Category { get; set; }

        public string Title { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string ContactPerson { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }
    }
}
