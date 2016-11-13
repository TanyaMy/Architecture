using Architecture.Data.Repositories.Interfaces;
using Architecture.Managers.Interfaces;

namespace Architecture.Managers.Implementations
{
    class RestorationsManager : IRestorationsManager
    {
        private readonly IRestorationsRepository _restorationsRepository;

        public RestorationsManager(IRestorationsRepository restorationsRepository)
        {
            _restorationsRepository = restorationsRepository;
        }
    }
}
