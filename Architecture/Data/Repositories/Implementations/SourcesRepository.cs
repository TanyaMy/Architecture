using System;
using System.Linq.Expressions;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;

namespace Architecture.Data.Repositories.Implementations
{
    class SourcesRepository : CrudRepositoryBase<Source, int>, ISourcesRepository
    {
        public SourcesRepository(AppDbContext appDbContext) 
            : base (appDbContext, appDbContext.Sources)
        {
                
        }

        protected override Expression<Func<Source, bool>>
            KeyPredicate(int id) => (a => a.Id == id);
    }
}
