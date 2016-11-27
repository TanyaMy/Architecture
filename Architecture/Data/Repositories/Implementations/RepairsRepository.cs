using System.Threading.Tasks;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Architecture.Data.Repositories.Implementations
{
    class RepairsRepository : CrudRepositoryBase<Repair>, IArchitectureSourceRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<Repair> _repairs;

        public RepairsRepository(AppDbContext appDbContext)
            : base(appDbContext, appDbContext.Repairs)
        {
            _appDbContext = appDbContext;
            _repairs = appDbContext.Repairs;
        }

        public Task<Repair> GetRepairById(int architectureId, RestorationKind restorationKind, DateTime restorationDate)
        {
            return _repairs.SingleOrDefaultAsync(r =>
                r.ArchitectureId == architectureId
                && r.RestorationKind == restorationKind
                && r.RestorationDate == restorationDate);
        }

        public async Task RemoveRepair(int architectureId, RestorationKind restorationKind, DateTime restorationDate)
        {
            var repair = await GetRepairById(architectureId, restorationKind, restorationDate);

            await RemoveItemAsync(repair);
        }
    }
}
