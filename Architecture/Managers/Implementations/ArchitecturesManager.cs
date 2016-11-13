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
    }
}
