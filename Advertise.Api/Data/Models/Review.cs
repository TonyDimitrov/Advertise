namespace Advertise.Api.Data.Models
{
    public class Review : BaseModel
    {
        public string Description { get; set; }

        public int Rate { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        //public int UserId { get; set; }

        //public virtual User User { get; set; }
    }
}
