namespace Advertise.Api.Data.Models
{
    public class Review : BaseModel
    {
        public string Description { get; set; }

        public int Rate { get; set; }

        public int ProductId { get; set; }

        public virtual Property Property { get; set; }
    }
}
