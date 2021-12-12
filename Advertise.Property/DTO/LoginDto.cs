using Advertise.Property.Constants;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Property.DTO
{
    public class LoginDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [MaxLength(ValidationConstants.UserPasswordMaxLen)]
        [MinLength(ValidationConstants.UserPasswordMinLen)]
        [Required]
        public string Password { get; set; }
    }
}
