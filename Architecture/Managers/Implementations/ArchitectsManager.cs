using Architecture.Data.Repositories.Interfaces;
using Architecture.Managers.Interfaces;

namespace Architecture.Managers.Implementations
{
    class ArchitectsManager : IArchitectsManager
    {
        private readonly IArchitectsRepository _architectsRepository;

        public ArchitectsManager(IArchitectsRepository architectsRepository)
        {
            _architectsRepository = architectsRepository;
        }
    }
}
