namespace Advertise.Api.Data.Models
{
    public class Image : BaseModel
    {
        public int ProductId { get; set; }

        public virtual Property Property { get; set; }

        public string Name { get; set; }

        public bool IsMain { get; set; }
    }
}
