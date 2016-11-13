using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;

namespace Architecture.Data.Repositories.Implementations
{
    class RestorationsRepository : CrudRepositoryBase<Restoration, RestorationKind>, IRestorationsRepository
    {
        public RestorationsRepository(AppDbContext appDbContext) 
            : base (appDbContext, appDbContext.Restorations)
        {

        }

        public async Task<IEnumerable<Repair>> GetLinkedRepairs(RestorationKind restorationKind)
        {
            var restoration = await GetItemAsync(restorationKind);

            return restoration.Repairs;
        }

        protected override Expression<Func<Restoration, bool>>
            KeyPredicate(RestorationKind restorationKind) => (a => a.RestorationKind == restorationKind);
    }
}
