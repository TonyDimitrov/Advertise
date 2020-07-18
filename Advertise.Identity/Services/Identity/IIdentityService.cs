using System.Threading.Tasks;
using Advertise.Common.Services;
using Advertise.Identity.Data.Models;
using Advertise.Identity.Models.Identity;

namespace Advertise.Identity.Services.Identity
{
    public interface IIdentityService
    {

        public interface IIdentityService
        {
            Task<Result<User>> Register(UserInputModel userInput);

            Task<Result<UserOutputModel>> Login(UserInputModel userInput);

            Task<Result> ChangePassword(string userId, ChangePasswordInputModel changePasswordInput);
        }
    }
}
