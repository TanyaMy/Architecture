using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Data.Entities;
using Architecture.Data.Repositories.Interfaces;
using Architecture.Managers.Interfaces;
using System;

namespace Architecture.Managers.Implementations
{
    class ArchitectureSourceManager : IArchitectureSourceManager
    {
        private readonly IArchitectureSourcesRepository _architectureSourceRepository;

        public ArchitectureSourceManager(IArchitectureSourcesRepository architectureSourceRepository)
        {
            _architectureSourceRepository = architectureSourceRepository;
        }  
      
        public Task<ArchitectureSource> GetArchitectureSourceById(int architectureId, int sourceId)
        {
            return _architectureSourceRepository.GetArchitectureSourceById(architectureId, sourceId);
        }

        public Task<ArchitectureSource> AddArchitectureSource(ArchitectureSource architectureSource)
        {
            return _architectureSourceRepository.AddItemAsync(architectureSource);
        }

        public Task<ArchitectureSource> UpdateArchitectureSource(ArchitectureSource architectureSource)
        {
            return _architectureSourceRepository.UpdateItemAsync(architectureSource);
        }

        public Task RemoveArchitectureSource(int architectureId, int sourceId)
        {
            return _architectureSourceRepository.RemoveArchitectureSource(architectureId, sourceId);
        }
    }
}
