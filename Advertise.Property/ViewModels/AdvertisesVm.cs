using Advertise.Property.Data.Models.Enums;

namespace Advertise.Property.ViewModels
{
    public class AdvertisesVm
    {
        public AdvertiseType Type { get; set; }

        public string Image { get; set; }
        public string Title { get; set; }

        public PropertyVm Property { get; set; }
    }
}
