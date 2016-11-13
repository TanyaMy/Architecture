using System;
using System.Linq.Expressions;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;

namespace Architecture.Data.Repositories.Implementations
{
    class RepairsRepository : CrudRepositoryBase<Repair, int>, IRepairsRepository
    {
        public RepairsRepository(AppDbContext appDbContext) 
            : base (appDbContext, appDbContext.Repairs)
        {
                
        }

        protected override Expression<Func<Repair, bool>>
            KeyPredicate(int id) => (a => a.Id == id);
    }
}
