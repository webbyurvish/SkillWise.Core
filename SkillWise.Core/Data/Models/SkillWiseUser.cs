using Microsoft.AspNetCore.Identity;

namespace SkillWise.Core.Data.Models
{
    public class SkillWiseUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
