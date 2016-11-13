using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;
using Architecture.Managers.Interfaces;

namespace Architecture.Managers.Implementations
{
    class SourcesManager : ISourcesManager
    {
        private readonly ISourcesRepository _sourcesRepository;

        public SourcesManager(ISourcesRepository sourcesRepository)
        {
            _sourcesRepository = sourcesRepository;
        }

        public Task<IEnumerable<Source>> GetSources()
        {
            return _sourcesRepository.GetItemsAsync();
        }

        public Task<IEnumerable<Source>> GetSourcesByArchitectureId(int architectureId)
        {
            return _sourcesRepository.GetSourcesByArchitectureId(architectureId);
        }

        public Task<Source> GetSourceById(int id)
        {
            return _sourcesRepository.GetItemAsync(id);
        }

        public Task<Source> AddSource(Source source)
        {
            return _sourcesRepository.AddItemAsync(source);
        }

        public Task<Source> UpdateSource(Source source)
        {
            return _sourcesRepository.UpdateItemAsync(source);
        }

        public Task RemoveSource(int id)
        {
            return _sourcesRepository.RemoveItemAsync(id);
        }
    }
}
