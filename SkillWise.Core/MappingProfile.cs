using AutoMapper;
using SkillWise.Core.Data.Models;
using SkillWise.Core.DataTransferObjects;

namespace SkillWise.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, SkillWiseUser>();
        }
    }
}
