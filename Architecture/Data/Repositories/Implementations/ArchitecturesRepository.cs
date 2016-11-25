using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Data.Repositories.Implementations
{
    class ArchitecturesRepository : CrudRepositoryBase<Entities.Architecture, int>, IArchitecturesRepository
    {
        private readonly DbSet<ArchitectureSource> _architectureSources;

        public ArchitecturesRepository(AppDbContext appDbContext) 
            : base (appDbContext, appDbContext.Architectures)
        {
            _architectureSources = appDbContext.ArchitecturesSources;
        }

        public async Task<IEnumerable<Repair>> GetLinkedRepairs(int architectureId)
        {
            var architecture = await GetItemAsync(architectureId);

            return architecture.Repairs;
        }

        public async Task<IEnumerable<Entities.Architecture>> GetArchitecturesBySourceId(int sourceId)
        {
            return await _architectureSources
                .Where(x => x.SourceId == sourceId)
                .Select(x => x.Architecture)
                .ToArrayAsync();
        }

        public List<Entities.Architecture> GetArchitecturesListBySourceId(int sourceId)
        {
            return _architectureSources
                .Where(x => x.SourceId == sourceId)
                .Select(x => x.Architecture)
                .ToList();
        }

        public async Task<IEnumerable<Entities.Architecture>> GetArchitecturesByArchitectId(int architectId)
        {
            return await _architectureSources
                .Where(x => x.ArchitectureId == architectId)
                .Select(x => x.Architecture)
                .ToArrayAsync();
        }

        protected override Expression<Func<Entities.Architecture, bool>>
            KeyPredicate(int id) => (a => a.Id == id);
    }
}
