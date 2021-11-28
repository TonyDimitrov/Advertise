namespace Advertise.Property.Data.Models
{
    using System;
    public class BaseModel
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime DeletedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
