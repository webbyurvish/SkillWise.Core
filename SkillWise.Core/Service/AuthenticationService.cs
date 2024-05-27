using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SkillWise.Core.Data.Models;
using SkillWise.Core.DataTransferObjects;
using SkillWise.Core.Service.Contracts;

namespace SkillWise.Core.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<SkillWiseUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationService(IMapper mapper, UserManager<SkillWiseUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<SkillWiseUser>(userForRegistration);

            var result = await _userManager.CreateAsync(user);

            foreach (string role in userForRegistration.Roles)
            {
                if(_roleManager.FindByNameAsync(role) is null)
                {
                    await _roleManager.CreateAsync(new IdentityRole
                    {
                        Name = role,
                        NormalizedName = role.ToUpper()
                    });
                }
            }

            if (result.Succeeded)
                await _userManager.AddToRolesAsync(user, userForRegistration.Roles);

            return result;
        }

        public Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication)
        {
            throw new NotImplementedException();
        }
    }
}
