using System.Threading.Tasks;
using Architecture.Data.Entities;
using System;

namespace Architecture.Data.Repositories.Interfaces
{
    public interface IArchitectureSourcesRepository : ICrudRepositoryBase<ArchitectureSource>
    {
        Task<ArchitectureSource> GetArchitectureSourceById(int architectureId, int sourceId);

        Task RemoveArchitectureSource(int architectureId, int sourceId);
    }
}
