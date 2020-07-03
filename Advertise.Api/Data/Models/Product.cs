namespace Advertise.Api.Data.Models
{
    using Advertise.Api.Data.Models.Enums;
    using System.Collections.Generic;

    public class Product : BaseModel
    {
        public Product()
        {
            this.Images = new HashSet<Image>();
            this.Reviews = new HashSet<Review>();
        }
         
        public bool IsAvailable { get; set; }

        public bool IsVip { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int QuantityAvailable { get; set; }

        public double Price { get; set; }

        public double DiscountedPrice { get; set; }

        public ProductCondition Condition { get; set; }

        public string Location { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual HashSet<Image> Images { get; set; }

        public virtual HashSet<Review> Reviews { get; set; }
    }
}
