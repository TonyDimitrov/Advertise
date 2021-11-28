using Advertise.Property.Data.Models.Enums;

namespace Advertise.Property.ViewModels
{
    public class AdvertiseVm
    {
        public int Id { get; set; }

        public Category Category { get; set; }

        public string Title { get; set; }

        public string Town { get; set; }

        public string Location { get; set; }

        public int Ptice { get; set; }

        public string Image { get; set; }
    }
}
