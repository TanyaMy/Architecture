using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Data.Entities;
using ArchitectureModel = Architecture.Data.Entities.Architecture;

namespace Architecture.Managers.Interfaces
{
    public interface IArchitecturesManager
    {
        Task<IEnumerable<ArchitectureModel>> GetArchitectures();

        Task<IEnumerable<ArchitectureModel>> GetArchitecturesByStyleId(int styleId);

        Task<IEnumerable<ArchitectureModel>> GetArchitecturesBySourceId(int sourceId);

        Task<IEnumerable<ArchitectureModel>> GetArchitecturesByArchitectId(int architectId);

        Task<IEnumerable<ArchitectureModel>> GetArchitecturesByState(State state);

        Task<ArchitectureModel> GetArchitectureById(int id);

        Task<IEnumerable<Repair>> GetLinkedRepairs(int id);

        Task<ArchitectureModel> AddArchitecture(ArchitectureModel architecture);

        Task<ArchitectureModel> UpdateArchitecture(ArchitectureModel architecture);

        Task RemoveArchitecture(int id);
    }
}
