﻿namespace Advertise.Api.Data.Models
{
    using System.Collections.Generic;

    public class User : BaseModel
    {
        public User()
        {
            this.Reviews = new HashSet<Review>();
            this.Advertises = new HashSet<Advertise>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public virtual HashSet<Advertise> Advertises { get; set; }

        public virtual HashSet<Review> Reviews { get; set; }
    }
}
