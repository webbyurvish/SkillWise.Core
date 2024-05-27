using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SkillWise.Core.Data.Models;
using SkillWise.Core.Repository.Contracts;
using SkillWise.Core.Service.Contracts;

namespace SkillWise.Core.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager, UserManager<SkillWiseUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(mapper, userManager, roleManager));
        }
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
