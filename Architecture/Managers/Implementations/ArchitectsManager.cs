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
            return _architectsRepository.GetItemsAsync();
        }

        public Task<Architect> GetArchitectById(int id)
        {
            return _architectsRepository.GetItemAsync(id);
        }

        public Task<Architect> AddArchitect(Architect architect)
        {
            return _architectsRepository.AddItemAsync(architect);
        }

        public Task<Architect> UpdateArchitect(Architect architect)
        {
            return _architectsRepository.UpdateItemAsync(architect);
        }

        public Task RemoveArchitect(int id)
        {
            return _architectsRepository.RemoveItemAsync(id);
        }
    }
}
