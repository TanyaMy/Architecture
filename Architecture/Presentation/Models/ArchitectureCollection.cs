using System.Collections.Generic;
using System.Linq;

namespace Architecture.Presentation.Models
{
    public static class ArchitectureCollection
    {
        
            //Список архитектурных произведений.
            public static List<Data.Entities.Architecture> ArchitectureList
                = new List<Data.Entities.Architecture>();            

            //Добавление в список.
            public static void AddArchitecture(Data.Entities.Architecture arch)
            {
                arch.Id = ArchitectureList.LastOrDefault()?.Id + 1 ?? 1;
                ArchitectureList.Add(arch);
            }

            //Удаление по Id. 
            public static void DeleteArchitecture(int id)
            {
                var foundArch = ArchitectureList.SingleOrDefault(x => x.Id == id);
                if (foundArch != null)
                ArchitectureList.Remove(foundArch);
                else
                    throw new KeyNotFoundException("Id was not found!");
            }

            //Замена архитектуры с указанным Id друой архитектурой.
            public static void ChangeArchitecture(int id, Data.Entities.Architecture arch)
            {
                var foundArch = ArchitectureList.SingleOrDefault(x => id == x.Id);
                if (foundArch != null)
                {
                    arch.Id = id;
                ArchitectureList[(ArchitectureList.IndexOf(foundArch))] = arch;
                }
                else
                    throw new KeyNotFoundException("Id was not found!");
            }            

            //получение объекта по указанному Id.
            public static Data.Entities.Architecture GetArchitectureById(int id)
            {
                return ArchitectureList.SingleOrDefault(x => x.Id == id);
            }        

    }
}
