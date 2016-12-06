using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Data.Entities;
using System;

namespace Architecture.Managers.Interfaces
{
    public interface IArchitectureSourceManager
    {       

        Task<ArchitectureSource> AddArchitectureSource(ArchitectureSource architectureSource);

        Task<ArchitectureSource> UpdateArchitectureSource(ArchitectureSource architectureSource);

        Task RemoveArchitectureSource(int architectureId, int sourceId);
    }
}
