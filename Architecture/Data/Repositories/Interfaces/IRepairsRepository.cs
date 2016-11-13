using System.Threading.Tasks;
using Architecture.Data.Entities;

namespace Architecture.Data.Repositories.Interfaces
{
    public interface IRepairsRepository : ICrudRepositoryBase<Repair>
    {
        Task<Repair> GetRepairById(int architectureId, RestorationKind restorationKind);

        Task<Repair> AddRepair(Repair repair);

        Task<Repair> UpdateRepair(Repair repair);

        Task RemoveRepair(int architectureId, RestorationKind restorationKind);
    }
}
