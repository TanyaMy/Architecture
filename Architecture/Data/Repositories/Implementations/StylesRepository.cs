using System;
using System.Linq.Expressions;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;

namespace Architecture.Data.Repositories.Implementations
{
    class StylesRepository : CrudRepositoryBase<Style, int>, IStylesRepository
    {
        public StylesRepository(AppDbContext appDbContext) 
            : base (appDbContext, appDbContext.Styles)
        {
                
        }

        protected override Expression<Func<Style, bool>>
            KeyPredicate(int id) => (a => a.Id == id);
    }
}
