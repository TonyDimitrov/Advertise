using Advertise.Property.Data.Models;
using Advertise.Property.Data.Repository;
using Advertise.Property.DTO;
using Advertise.Property.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Advertise.Property.Services
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
        public async Task<PageAdvertisesVm> Get(int? pageSize, int? page)
        {
            pageSize ??= 5;
            page ??= 1;

            var advertises = await this.advertiseRepository.All()
                .OrderByDescending(ad => ad.CreatedOn)
                .Select(ad => new AdvertiseVm
                {
                    Id = ad.Id,
                    Category = ad.Category,
                    Title = ad.Title,
                    Town = ad.Property.Town,
                    Location = ad.Property.Location,
                    Ptice = (int)ad.Property.Price,
                    Image = ad.Property.Images.FirstOrDefault().Name,
                })
                .Skip(pageSize.Value * (page.Value - 1))
                .Take(pageSize.Value)
                .ToListAsync();

            var totalPages = (int)Math.Ceiling(this.advertiseRepository.All().Count() / (double)pageSize);

            var advertisePage = new PageAdvertisesVm
            {
                Advertises = advertises,
                Page = page.Value,
                PageSize = pageSize.Value,
                TotalPages = totalPages,
                IsFirstPage = page == 1,
                IsLastPage = page == totalPages
            };

            return await Task.FromResult(advertisePage);
        }

        public async Task Create(CreateAdvertiseDTO advertise, int userId, string filePath)
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
                Property = new Data.Models.Property
                {
                    CreatedOn = DateTime.UtcNow,
                    Country = advertise.Property.Country,
                    Town = advertise.Property.Town,
                    Location = advertise.Property.Location,
                    Description = advertise.Property.Description,
                    Lease = advertise.Property.Lease,
                    Price = advertise.Property.Price,
                    Deposit = advertise.Property.Deposit,
                    Images = (await this.filesService.SaveFiles(advertise.Property.Images, filePath).ToListAsync())
                    .Select(img => new Image
                    {
                        Name = img,
                        CreatedOn = DateTime.UtcNow
                    })
                    .ToHashSet()
                }
            };

            await this.advertiseRepository.AddAsync(ad);

            await this.advertiseRepository.SaveChangesAsync();
        }

        public async Task<bool> Update(UpdateAdvertiseDTO advertise, string filePath)
        {
            var dbAd = await this.advertiseRepository.All().FirstOrDefaultAsync(a => a.Id == advertise.Id);

            dbAd.Category = advertise.Category;
            dbAd.ContactPerson = advertise.ContactPerson;
            dbAd.ContactEmail = advertise.ContactEmail;
            dbAd.ContactPhone = advertise.ContactPhone;
            dbAd.Title = advertise.Title;
            dbAd.Type = advertise.Type;
            dbAd.CreatedOn = DateTime.UtcNow;
            dbAd.Property = new Data.Models.Property
            {
                CreatedOn = DateTime.UtcNow,
                Country = advertise.Property.Country,
                Town = advertise.Property.Town,
                Location = advertise.Property.Location,
                Description = advertise.Property.Description,
                Lease = advertise.Property.Lease,
                Price = advertise.Property.Price,
                Deposit = advertise.Property.Deposit,
                Images = (await this.filesService.SaveFiles(advertise.Property.Images, filePath).ToListAsync())
        .Select(img => new Image
        {
            Name = img,
            CreatedOn = DateTime.UtcNow
        })
        .ToHashSet()
            };

            await this.advertiseRepository.AddAsync(dbAd);

            return (await this.advertiseRepository.SaveChangesAsync()) != 0;
        }

        public async Task<bool> Delete(int id)
        {
            var dbAd = await this.advertiseRepository.All().FirstOrDefaultAsync();
            await this.advertiseRepository.SoftDelete(dbAd);

            return (await this.advertiseRepository.SaveChangesAsync()) != 0;
        }

        public async Task<DetailsPropertyDTO> GetById(int id)
        {
            var property = this.advertiseRepository.All()
             .Include(a => a.Property)
             .ThenInclude(p => p.Images)
             .FirstOrDefault(a => a.Id == id);

            return await Task.FromResult(
              new DetailsPropertyDTO
              {
                  Category = property.Category,
                  ContactEmail = property.ContactEmail,
                  ContactPerson = property.ContactPerson,
                  ContactPhone = property.ContactPhone,
                  Country = property.Property.Country,
                  Deposit = property.Property.Deposit,
                  Description = property.Property.Description,
                  Lease = property.Property.Lease,
                  Location = property.Property.Location,
                  Price = property.Property.Price,
                  PropertyId = property.Property.Id,
                  Title = property.Title,
                  Town = property.Property.Town,
                  Images = property.Property.Images
                  .Select(i => i.Name)
                  .ToHashSet()
              });
        }
    }
}