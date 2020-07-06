namespace Advertise.Api.ViewModels
{
    public class PageAdvertisesVm
    {
        public PageAdvertisesVm()
        {
            this.Page = 1;
            this.PageSize = 10;
        }

        public int TotalPages { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public bool IsFirstPage { get; set; }

        public bool IsLastPage { get; set; }

        public AdvertisesVm Advertises { get; set; }
    }
}
