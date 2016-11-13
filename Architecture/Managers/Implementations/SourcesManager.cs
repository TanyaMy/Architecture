using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Source>> GetSourceByArchitectureId(int architectureId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Source> GetSourceById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Source> AddSource(Source source)
        {
            throw new System.NotImplementedException();
        }

        public Task<Source> UpdateSource(Source source)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveSource(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
