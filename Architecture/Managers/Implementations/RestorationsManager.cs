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
            return _restorationsRepository.GetItemsAsync();
        }

        public Task<Restoration> GetRestorationByRestorationKind(RestorationKind restorationKind)
        {
            return _restorationsRepository.GetItemAsync(restorationKind);
        }

        public Task<IEnumerable<Repair>> GetLinkedRepairs(RestorationKind restorationKind)
        {
            return _restorationsRepository.GetLinkedRepairs(restorationKind);
        }

        public Task<Restoration> AddRestoration(Restoration restoration)
        {
            return _restorationsRepository.AddItemAsync(restoration);
        }

        public Task<Restoration> UpdateRestoration(Restoration restoration)
        {
            return _restorationsRepository.UpdateItemAsync(restoration);
        }

        public Task RemoveRestoration(RestorationKind restorationKind)
        {
            return _restorationsRepository.RemoveItemAsync(restorationKind);
        }
    }
}
