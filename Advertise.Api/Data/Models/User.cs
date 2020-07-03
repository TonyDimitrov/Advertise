namespace Advertise.Api.Data.Models
{
    using System.Collections.Generic;

    public class User : BaseModel
    {
        public User()
        {
            this.Reviews = new HashSet<Review>();
            this.Products = new HashSet<Product>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public virtual HashSet<Product> Products { get; set; }

        public virtual HashSet<Review> Reviews { get; set; }
    }
}
