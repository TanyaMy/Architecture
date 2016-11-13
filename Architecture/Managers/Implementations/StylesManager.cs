using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;
using Architecture.Managers.Interfaces;

namespace Architecture.Managers.Implementations
{
    class StylesManager : IStylesManager
    {
        private readonly IStylesRepository _stylesRepository;

        public StylesManager(IStylesRepository stylesRepository)
        {
            _stylesRepository = stylesRepository;
        }

        public Task<IEnumerable<Style>> GetStyles()
        {
            throw new System.NotImplementedException();
        }

        public Task<Style> GetStyleById(int styleId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Style> AddStyle(Style style)
        {
            throw new System.NotImplementedException();
        }

        public Task<Style> UpdateStyle(Style style)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveStyle(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
