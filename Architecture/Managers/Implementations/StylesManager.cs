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
            return _stylesRepository.GetItemsAsync();
        }

        public Task<Style> GetStyleById(int styleId)
        {
            return _stylesRepository.GetItemAsync(styleId);
        }

        public Task<Style> AddStyle(Style style)
        {
            return _stylesRepository.AddItemAsync(style);
        }

        public Task<Style> UpdateStyle(Style style)
        {
            return _stylesRepository.UpdateItemAsync(style);
        }

        public Task RemoveStyle(int id)
        {
            return _stylesRepository.RemoveItemAsync(id);
        }
    }
}
