using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;
using System.Linq;

namespace Architecture.Data.Repositories.Implementations
{
    class ArchitecturesRepository : CrudRepositoryBase<Entities.Architecture, int>, IArchitecturesRepository
    {
        public ArchitecturesRepository(AppDbContext appDbContext) 
            : base (appDbContext, appDbContext.Architectures)
        {
                
        }

        public async Task<IEnumerable<Repair>> GetLinkedRepairs(int architectureId)
        {
            var architecture = await GetItemAsync(architectureId);

            return architecture.Repairs;
        }

        protected override Expression<Func<Entities.Architecture, bool>>
            KeyPredicate(int id) => (a => a.Id == id);
    }
}
