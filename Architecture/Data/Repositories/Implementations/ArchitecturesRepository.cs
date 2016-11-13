using System;
using System.Linq.Expressions;
using Architecture.Data.Repositories.Interfaces;

namespace Architecture.Data.Repositories.Implementations
{
    class ArchitecturesRepository : CrudRepositoryBase<Entities.Architecture, int>, IArchitecturesRepository
    {
        public ArchitecturesRepository(AppDbContext appDbContext) 
            : base (appDbContext, appDbContext.Architectures)
        {
                
        }

        protected override Expression<Func<Entities.Architecture, bool>>
            KeyPredicate(int id) => (a => a.Id == id);
    }
}
