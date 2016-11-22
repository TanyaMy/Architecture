using Architecture.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Data.Repositories.Implementations
{
    public class ReportsRepository : IReportsRepository
    {
        private readonly DbSet<Entities.Architecture> _architectures;

        public Task<IEnumerable<object>> GetArchitecturesRepairs()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<object>> GetArchitecturesStates()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetOldArchitectures()
        {
            return _architectures.Where(a => a.CreationYear < 1800)
                .OrderByDescending(a => a.CreationYear)
                .Select(a => (object)new { Title = a.Title, CreationYear = a.CreationYear }).AsEnumerable();
        }
    }
}
