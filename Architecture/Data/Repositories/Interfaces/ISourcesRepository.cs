using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Data.Entities;

namespace Architecture.Data.Repositories.Interfaces
{
    public interface ISourcesRepository : ICrudRepositoryBase<Source, int>
    {
        Task<IEnumerable<Source>> GetSourcesByArchitectureId(int architectureId);      
    }
}
