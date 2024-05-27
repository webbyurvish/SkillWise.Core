using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkillWise.Core.Data.Models;
using SkillWise.Core.Repository.Configuration;

namespace SkillWise.Core.Data
{
    public class SWDbContext : IdentityDbContext<SkillWiseUser>
    {
        public SWDbContext(DbContextOptions<SWDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
