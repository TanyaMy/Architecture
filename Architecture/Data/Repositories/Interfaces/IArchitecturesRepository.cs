using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Data.Entities;

namespace Architecture.Data.Repositories.Interfaces
{
    public interface IArchitecturesRepository : ICrudRepositoryBase<Entities.Architecture, int>
    {
        Task<IEnumerable<Repair>> GetLinkedRepairs(int architectureId);
    }
}
