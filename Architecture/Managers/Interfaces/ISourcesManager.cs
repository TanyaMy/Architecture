﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Data.Entities;

namespace Architecture.Managers.Interfaces
{
    public interface ISourcesManager
    {
        Task<IEnumerable<Source>> GetSources();

        Task<IEnumerable<Source>> GetSourcesByArchitectureId(int architectureId);

        Task<Source> GetSourceById(int id);

        Task<Source> AddSource(Source source);

        Task<Source> UpdateSource(Source source);

        Task RemoveSource(int id);

        //Task RemoveSourceArchitecture(int sourceId, int architectureId);
    }
}
