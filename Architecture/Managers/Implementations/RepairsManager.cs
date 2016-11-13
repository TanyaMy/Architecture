using Architecture.Data.Repositories.Interfaces;
using Architecture.Managers.Interfaces;

namespace Architecture.Managers.Implementations
{
    class RepairsManager : IRepairsManager
    {
        private readonly IRepairsRepository _repairsRepository;

        public RepairsManager(IRepairsRepository repairsRepository)
        {
            _repairsRepository = repairsRepository;
        }
    }
}
