using SkillWise.Core.Data;
using SkillWise.Core.Repository.Contracts;

namespace SkillWise.Core.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly SWDbContext _sWDbContext;

        public RepositoryManager(SWDbContext sWDbContext)
        {
            _sWDbContext = sWDbContext;
        }

        public async Task SaveAsync()
        {
            await _sWDbContext.SaveChangesAsync();
        }
    }
}
