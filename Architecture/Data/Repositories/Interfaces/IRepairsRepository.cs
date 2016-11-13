using System.Threading.Tasks;
using Architecture.Data.Entities;

namespace Architecture.Data.Repositories.Interfaces
{
    public interface IRepairsRepository : ICrudRepositoryBase<Repair>
    {
        Task<Repair> GetRepairById(int architectureId, RestorationKind restorationKind);

        Task RemoveRepair(int architectureId, RestorationKind restorationKind);
    }
}
