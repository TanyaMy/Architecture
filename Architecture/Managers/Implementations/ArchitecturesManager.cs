using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;
using Architecture.Managers.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            return _architecturesRepository.GetItemsAsync(x => 
            x.Include(y => y.Architect).Include(y => y.Style));
        }

        public Task<IEnumerable<Data.Entities.Architecture>> GetArchitecturesByStyleId(int styleId)
        {
            return _architecturesRepository
                .GetItemsAsync(items => items.Where(x => x.StyleId == styleId));
        }

        public Task<IEnumerable<Data.Entities.Architecture>> GetArchitecturesBySourceId(int sourceId)
        {
            return _architecturesRepository.GetArchitecturesBySourceId(sourceId);
        }

        public Task<IEnumerable<Data.Entities.Architecture>> GetArchitecturesByArchitectId(int architectId)
        {
            return _architecturesRepository.GetArchitecturesByArchitectId(architectId);
        }

        public async Task<IEnumerable<Data.Entities.Architecture>> GetArchitecturesByState(State state)
        {
            var architectures = await _architecturesRepository.GetItemsAsync();

            return architectures.Where(x => x.State == state);
        }

        public Task<Data.Entities.Architecture> GetArchitectureById(int id)
        {
            return _architecturesRepository.GetItemAsync(id);
        }

        public Task<IEnumerable<Repair>> GetLinkedRepairs(int id)
        {
            return _architecturesRepository.GetLinkedRepairs(id);
        }

        public Task<Data.Entities.Architecture> AddArchitecture(Data.Entities.Architecture architecture)
        {
            return _architecturesRepository.AddItemAsync(architecture);
        }

        public Task<Data.Entities.Architecture> UpdateArchitecture(Data.Entities.Architecture architecture)
        {
            return _architecturesRepository.UpdateItemAsync(architecture);
        }

        public Task RemoveArchitecture(int id)
        {
            return _architecturesRepository.RemoveItemAsync(id);
        }
    }
}
