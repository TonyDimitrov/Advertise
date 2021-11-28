namespace Advertise.Property.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Raffle : BaseModel
    {
        public Raffle()
        {
            this.RegisteredUsers = new HashSet<User>();
        }
        public bool IsActive { get; set; }
         
        public DateTime StartDate { get; set; }

        public DateTime EndData { get; set; }

        public DateTime DueDate { get; set; }

        public double WonDiscount { get; set; }

        public DateTime EndBonusDate { get; set; }

        public virtual HashSet<User> RegisteredUsers { get; set; }

        public int WinnerId { get; set; }

        public string BonusCode { get; set; }
    }
}
