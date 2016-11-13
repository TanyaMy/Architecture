using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;
using Architecture.Managers.Interfaces;

namespace Architecture.Managers.Implementations
{
    class ArchitectsManager : IArchitectsManager
    {
        private readonly IArchitectsRepository _architectsRepository;

        public ArchitectsManager(IArchitectsRepository architectsRepository)
        {
            _architectsRepository = architectsRepository;
        }

        public Task<IEnumerable<Architect>> GetArchitects()
        {
            throw new System.NotImplementedException();
        }

        public Task<Architect> GetArchitectById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Architect> AddArchitect(Architect architect)
        {
            throw new System.NotImplementedException();
        }

        public Task<Architect> UpdateArchitect(Architect architect)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveArchitect(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
