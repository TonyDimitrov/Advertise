namespace Advertise.Property.Data.Models
{
    public class Image : BaseModel
    {
        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }

        public string Name { get; set; }

        public bool IsMain { get; set; }
    }
}
