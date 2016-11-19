using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Data.Entities;

namespace Architecture.Managers.Interfaces
{
    public interface IArchitectManager
    {
        Task<IEnumerable<Architect>> GetArchitects();

        Task<Architect> GetArchitectById(int id);

        Task<Architect> AddArchitect(Architect architect);

        Task<Architect> UpdateArchitect(Architect architect);

        Task RemoveArchitect(int id);
    }
}
