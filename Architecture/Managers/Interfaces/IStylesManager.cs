using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Data.Entities;

namespace Architecture.Managers.Interfaces
{
    public interface IStylesManager
    {
        Task<IEnumerable<Style>> GetStyles();

        Task<Style> GetStyleById(int styleId);

        Task<Style> AddStyle(Style style);

        Task<Style> UpdateStyle(Style style);

        Task RemoveStyle(int id);
    }
}
