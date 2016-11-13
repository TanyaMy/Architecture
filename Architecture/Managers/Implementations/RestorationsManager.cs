using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Data.Entities;
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

        public Task<IEnumerable<Restoration>> GetRestorations()
        {
            throw new System.NotImplementedException();
        }

        public Task<Restoration> GetRestorationByRestorationKind(RestorationKind restorationKind)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Repair>> GetLinkedRepairs(RestorationKind restorationKind)
        {
            throw new System.NotImplementedException();
        }

        public Task<Restoration> AddRestoration(Restoration restoration)
        {
            throw new System.NotImplementedException();
        }

        public Task<Restoration> UpdateRestoration(Restoration restoration)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveRestoration(RestorationKind restorationKind)
        {
            throw new System.NotImplementedException();
        }
    }
}
