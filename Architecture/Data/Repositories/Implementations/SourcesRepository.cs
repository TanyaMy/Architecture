using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Data.Repositories.Implementations
{
    class SourcesRepository : CrudRepositoryBase<Source, int>, ISourcesRepository
    {
        private readonly DbSet<ArchitectureSource> _architectureSources;
        private readonly DbSet<Source> _sources;

        public SourcesRepository(AppDbContext appDbContext) 
            : base (appDbContext, appDbContext.Sources)
        {
            _architectureSources = appDbContext.ArchitecturesSources;
        }

        public async Task<IEnumerable<Source>> GetSourcesByArchitectureId(int architectureId)
        {
            return await _architectureSources
                .Where(x => x.ArchitectureId == architectureId)
                .Select(x => x.Source)
                .ToArrayAsync();
        }
     
        protected override Expression<Func<Source, bool>>
            KeyPredicate(int id) => (a => a.Id == id);
    }
}
