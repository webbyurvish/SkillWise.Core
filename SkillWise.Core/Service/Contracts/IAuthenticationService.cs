using Microsoft.AspNetCore.Identity;
using SkillWise.Core.DataTransferObjects;

namespace SkillWise.Core.Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication);
    }
}
