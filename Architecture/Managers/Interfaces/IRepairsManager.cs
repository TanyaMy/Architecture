using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Data.Entities;
using System;

namespace Architecture.Managers.Interfaces
{
    public interface IRepairsManager
    {
        Task<IEnumerable<Repair>> GetRepairs();

        Task<Repair> GetRepairById(int architectureId, RestorationKind restorationKind, DateTime restorationDate);

        Task<Repair> AddRepair(Repair repair);

        Task<Repair> UpdateRepair(Repair repair);

        Task RemoveRepair(int architectureId, RestorationKind restorationKind, DateTime restorationDate);
    }
}
