using System;
using System.Linq.Expressions;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;

namespace Architecture.Data.Repositories.Implementations
{
    class ArchitectsRepository : CrudRepositoryBase<Architect, int>, IArchitectsRepository
    {
        public ArchitectsRepository(AppDbContext appDbContext) 
            : base (appDbContext, appDbContext.Architects)
        {
                
        }

        protected override Expression<Func<Architect, bool>>
            KeyPredicate(int id) => (a => a.Id == id);
    }
}
