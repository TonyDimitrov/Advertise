using Advertise.Property.Constants;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Property.DTO
{
    public class CreateUserDTO
    {
        [MaxLength(ValidationConstants.UserNameMaxLen)]
        [MinLength(ValidationConstants.UserNameMinLen)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(ValidationConstants.UserNameMaxLen)]
        [MinLength(ValidationConstants.UserNameMinLen)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(ValidationConstants.UserAddressMaxLen)]
        [MinLength(ValidationConstants.UserAddressMinLen)]
        public string Address { get; set; }

        [MaxLength(ValidationConstants.AdContactPhoneMaxLen)]
        [MinLength(ValidationConstants.AdContactPhoneMinLen)]
        public string PhoneNumber { get; set; }
    }
}
