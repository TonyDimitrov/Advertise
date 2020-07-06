using Advertise.Api.Data.Models.Enums;

namespace Advertise.Api.ViewModels
{
    public class AdvertisesVm
    {
        public AdvertiseType Type { get; set; }

        public string Image { get; set; }

        public PropertyVm Property { get; set; }
    }
}
