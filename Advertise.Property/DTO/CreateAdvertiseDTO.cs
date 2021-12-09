using Advertise.Api.DTO;
using Advertise.Property.Constants;
using Advertise.Property.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Property.DTO
{
    public class CreateAdvertiseDTO
    {
        private CreateAdvertiseFlatDto flatDto;
        public CreateAdvertiseDTO()
        {
        }

        public CreateAdvertiseDTO(CreateAdvertiseFlatDto flatDto)
        {
            this.flatDto = flatDto;
            this.MapObject();
        }

        public AdvertiseType Type { get; set; }

        public Category Category { get; set; }

        [MaxLength(ValidationConstants.AdTitleMaxLen)]
        [MinLength(ValidationConstants.AdTitleMinLen)]
        [Required]
        public string Title { get; set; }

        [MaxLength(ValidationConstants.AdContactPersonMaxLen)]
        [MinLength(ValidationConstants.AdContactPersonMinLen)]
        [Required]
        public string ContactPerson { get; set; }

        [MaxLength(ValidationConstants.AdContactPhoneMaxLen)]
        [MinLength(ValidationConstants.AdContactPhoneMinLen)]
        public string ContactPhone { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required]
        public CreatePropertyDTO Property { get; set; }

        private void MapObject()
        {
            this.Type = flatDto.Type.Value;
            this.Category = flatDto.Category.Value;
            this.Title = flatDto.Title;
            this.ContactPerson = flatDto.ContactPerson;
            this.ContactPhone = flatDto.ContactPhone;
            this.ContactEmail = flatDto.ContactEmail;
            this.Property = new CreatePropertyDTO
            {
                Country = flatDto.Country,
                Deposit = flatDto.Deposit,
                Description = flatDto.Description,
                Lease = flatDto.Lease,
                Location = flatDto.Location,
                Price = flatDto.Price,
                Town = flatDto.Town,
                Images = flatDto.Images
            };
        }
    }
}
