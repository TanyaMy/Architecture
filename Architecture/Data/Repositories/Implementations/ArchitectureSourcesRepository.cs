using System.Threading.Tasks;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Architecture.Data.Repositories.Implementations
{
    class ArchitectureSourcesRepository : CrudRepositoryBase<ArchitectureSource>, IArchitectureSourcesRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<ArchitectureSource> _architectureSources;

        public ArchitectureSourcesRepository(AppDbContext appDbContext)
            : base(appDbContext, appDbContext.ArchitecturesSources)
        {
            _appDbContext = appDbContext;
            _architectureSources = appDbContext.ArchitecturesSources;
        }

        public Task<ArchitectureSource> GetArchitectureSourceById(int architectureId, int sourceId)
        {
            return _architectureSources.SingleOrDefaultAsync(aS =>
               aS.ArchitectureId == architectureId
               && aS.SourceId == sourceId);
        }

        public async Task RemoveArchitectureSource(int architectureId, int sourceId)
        {
            var archSource = await GetArchitectureSourceById(architectureId, sourceId);

            await RemoveItemAsync(archSource);
        }

       
    }
}
