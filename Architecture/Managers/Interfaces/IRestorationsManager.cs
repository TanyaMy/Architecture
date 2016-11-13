using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Data.Entities;

namespace Architecture.Managers.Interfaces
{
    public interface IRestorationsManager
    {
        Task<IEnumerable<Restoration>> GetRestorations();

        Task<Restoration> GetRestorationByRestorationKind(RestorationKind restorationKind);

        Task<Restoration> AddRestoration(Restoration restoration);

        Task<Restoration> UpdateRestoration(Restoration restoration);

        Task RemoveRestoration(RestorationKind restorationKind);
    }
}
