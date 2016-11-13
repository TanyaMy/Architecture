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
    }
}
