using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;
using Architecture.Managers.Interfaces;

namespace Architecture.Managers.Implementations
{
    class ArchitecturesManager : IArchitecturesManager
    {
        private readonly IArchitecturesRepository _architecturesRepository;

        public ArchitecturesManager(IArchitecturesRepository architecturesRepository)
        {
            _architecturesRepository = architecturesRepository;
        }

        public Task<IEnumerable<Data.Entities.Architecture>> GetArchitectures()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Data.Entities.Architecture>> GetArchitecturesByStyleId(int styleId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Data.Entities.Architecture>> GetArchitecturesBySourceId(int sourceId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Data.Entities.Architecture>> GetArchitecturesByArchitectId(int architectId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Data.Entities.Architecture>> GetArchitecturesByState(State state)
        {
            throw new System.NotImplementedException();
        }

        public Task<Data.Entities.Architecture> GetArchitectureById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Repair>> GetLinkedRepairs(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Data.Entities.Architecture> AddArchitecture(Data.Entities.Architecture architecture)
        {
            throw new System.NotImplementedException();
        }

        public Task<Data.Entities.Architecture> UpdateArchitecture(Data.Entities.Architecture architecture)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveArchitecture(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
