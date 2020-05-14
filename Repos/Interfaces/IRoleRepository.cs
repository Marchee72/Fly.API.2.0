using Entities.DatabaseModels;

namespace Repos.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetByName(string name);
    }
}
