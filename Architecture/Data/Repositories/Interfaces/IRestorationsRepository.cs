using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Data.Entities;

namespace Architecture.Data.Repositories.Interfaces
{
    public interface IRestorationsRepository : ICrudRepositoryBase<Restoration, RestorationKind>
    {
        Task<IEnumerable<Repair>> GetLinkedRepairs(RestorationKind restorationKind);
    }
}
