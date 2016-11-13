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
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Repair>> GetRepairsByArchitectureId(int architectureId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Repair>> GetRepairsByRestorationKind(RestorationKind restorationKind)
        {
            throw new System.NotImplementedException();
        }

        public Task<Repair> GetRepairById(int architectureId, RestorationKind restorationKind)
        {
            throw new System.NotImplementedException();
        }

        public Task<Repair> AddRepair(Repair repair)
        {
            throw new System.NotImplementedException();
        }

        public Task<Repair> UpdateRepair(Repair repair)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveRepair(int architectureId, RestorationKind restorationKind)
        {
            throw new System.NotImplementedException();
        }
    }
}
