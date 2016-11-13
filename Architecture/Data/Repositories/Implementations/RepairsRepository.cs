using System.Threading.Tasks;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Data.Repositories.Implementations
{
    class RepairsRepository : CrudRepositoryBase<Repair>, IRepairsRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<Repair> _repairs;

        public RepairsRepository(AppDbContext appDbContext)
            : base(appDbContext, appDbContext.Repairs)
        {
            _appDbContext = appDbContext;
            _repairs = appDbContext.Repairs;
        }

        public Task<Repair> GetRepairById(int architectureId, RestorationKind restorationKind)
        {
            return _repairs.SingleOrDefaultAsync(r =>
                r.ArchitectureId == architectureId
                && r.RestorationKind == restorationKind);
        }

        public async Task<Repair> AddRepair(Repair repair)
        {
            await _repairs.AddAsync(repair);

            await _appDbContext.SaveChangesAsync();

            return repair;
        }

        public Task<Repair> UpdateRepair(Repair repair)
        {
            return UpdateItemAsync(repair);
        }

        public async Task RemoveRepair(int architectureId, RestorationKind restorationKind)
        {
            var repair = await GetRepairById(architectureId, restorationKind);

            await RemoveItemAsync(repair);
        }
    }
}
