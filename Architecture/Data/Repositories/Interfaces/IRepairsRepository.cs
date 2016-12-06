using System.Threading.Tasks;
using Architecture.Data.Entities;
using System;

namespace Architecture.Data.Repositories.Interfaces
{
    public interface IRepairsRepository : ICrudRepositoryBase<Repair>
    {
        Task<Repair> GetRepairById(int architectureId, RestorationKind restorationKind, DateTime restorationDate);

        Task RemoveRepair(int architectureId, RestorationKind restorationKind, DateTime restorationDate);
    }
}
