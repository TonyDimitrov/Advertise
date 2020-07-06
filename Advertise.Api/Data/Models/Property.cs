namespace Advertise.Api.Data.Models
{
    using System.Collections.Generic;

    public class Property : BaseModel
    {
        public Property()
        {
            this.Images = new HashSet<Image>();
            this.Reviews = new HashSet<Review>();
        }

        public string Description { get; set; }

        public double Price { get; set; }

        public double Deposit { get; set; }

        public string Lease { get; set; }

        public double DiscountedPrice { get; set; }

        public string Location { get; set; }

        public string Country { get; set; }

        public string County { get; set; }

        public string Town { get; set; }

        public virtual Advertise Advertise { get; set; }

        public virtual HashSet<Image> Images { get; set; }

        public virtual HashSet<Review> Reviews { get; set; }
    }
}
