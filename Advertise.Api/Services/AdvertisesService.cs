using Advertise.Api.Data.Models;
using Advertise.Api.Data.Repository;
using Advertise.Api.DTO;
using Advertise.Api.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Advertise.Api.Services
{
    public class AdvertisesService : IAdvertisesService
    {
        private readonly IEntityRepository<Data.Models.Advertise> advertiseRepository;
        private readonly IFilesService filesService;

        public AdvertisesService(IEntityRepository<Data.Models.Advertise> advertiseRepository, IFilesService filesService)
        {
            this.advertiseRepository = advertiseRepository;
            this.filesService = filesService;
        }
        public async Task<PageAdvertisesVm> Get(int pageSize, int page)
        {
            var advertises = this.advertiseRepository.All()
                .OrderByDescending(ad => ad.CreatedOn)
                .Select(ad => new AdvertisesVm
                {
                    Image = ad.Property.Images.FirstOrDefault().Name,
                    Type = ad.Type,
                    Title = ad.Title,
                    Property = new PropertyVm
                    {
                        Lease = ad.Property.Lease,
                        Location = ad.Property.Location,
                        Price = ad.Property.Price
                    }
                })
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToList();

            var totalPages = (int)Math.Ceiling(this.advertiseRepository.All().Count() / (double)pageSize);

            var advertisePage = new PageAdvertisesVm
            {
                Advertises = advertises,
                Page = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                IsFirstPage = page == 1,
                IsLastPage = page == totalPages
            };

            return await Task.FromResult(advertisePage);
        }

        public Task<PageAdvertisesVm> Create(CreateAdvertiseDTO advertise, int userId, string filePath)
        {
            var ad = new Data.Models.Advertise
            {
                Category = advertise.Category,
                ContactPerson = advertise.ContactPerson,
                ContactEmail = advertise.ContactEmail,
                ContactPhone = advertise.ContactPhone,
                Title = advertise.Title,
                Type = advertise.Type,
                CreatedOn = DateTime.UtcNow,
                UserId = userId,
                Property = new Property
                {
                    CreatedOn = DateTime.UtcNow,
                    Country = advertise.Property.Country,
                    County = advertise.Property.County,
                    Town = advertise.Property.Town,
                    Location = advertise.Property.Location,
                    Description = advertise.Property.Description,
                    Lease = advertise.Property.Lease,
                    Price = advertise.Property.Price,
                    Deposit = advertise.Property.Deposit,
                    Images = this.filesService.SaveFiles(advertise.Property.Images, filePath)
                    .Select(img => new Image
                    {
                        Name = img,
                        CreatedOn = DateTime.UtcNow
                    })
                    .ToHashSet()
                }
            };

            throw new NotImplementedException();
        }

        public Task<PageAdvertisesVm> Update(CreateAdvertiseDTO advertise)
        {
            throw new NotImplementedException();
        }

        public Task<PageAdvertisesVm> Delete(CreateAdvertiseDTO advertise)
        {
            throw new NotImplementedException();
        }
    }
}