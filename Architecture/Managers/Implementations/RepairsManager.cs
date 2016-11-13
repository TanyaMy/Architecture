using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Data.Entities;
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

        public Task<IEnumerable<Repair>> GetRepairs()
        {
            return _repairsRepository.GetItemsAsync();
        }

        public Task<Repair> GetRepairById(int architectureId, RestorationKind restorationKind)
        {
            return _repairsRepository.GetRepairById(architectureId, restorationKind);
        }

        public Task<Repair> AddRepair(Repair repair)
        {
            return _repairsRepository.AddItemAsync(repair);
        }

        public Task<Repair> UpdateRepair(Repair repair)
        {
            return _repairsRepository.UpdateItemAsync(repair);
        }

        public Task RemoveRepair(int architectureId, RestorationKind restorationKind)
        {
            return _repairsRepository.RemoveRepair(architectureId, restorationKind);
        }
    }
}
