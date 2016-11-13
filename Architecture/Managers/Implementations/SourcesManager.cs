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
    }
}
