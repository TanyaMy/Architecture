using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Data.Entities;


namespace Architecture.Data.Repositories.Interfaces
{
    public interface IReportsRepository
    {
        IEnumerable<object> GetOldArchitectures();

        Task<IEnumerable<object>> GetArchitecturesStates();

        Task<IEnumerable<object>> GetArchitecturesRepairs();
    }
}
