using System;
using System.Linq.Expressions;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;

namespace Architecture.Data.Repositories.Implementations
{
    class RestorationsRepository : CrudRepositoryBase<Restoration, int>, IRestorationsRepository
    {
        public RestorationsRepository(AppDbContext appDbContext) 
            : base (appDbContext, appDbContext.Restorations)
        {
                
        }

        protected override Expression<Func<Restoration, bool>>
            KeyPredicate(int id) => (a => a.Id == id);
    }
}
