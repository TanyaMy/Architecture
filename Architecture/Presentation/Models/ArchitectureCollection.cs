using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Presentation.Models
{
    public static class ArchitectureCollection
    {
        
            //Список архитектурных произведений.
            public static List<Architecture> ArchitectureList
                = new List<Architecture>();            

            //Добавление в список.
            public static void AddArchitecture(Architecture arch)
            {
                arch.ArchitectureId = ArchitectureList.LastOrDefault()?.ArchitectureId + 1 ?? 1;
                ArchitectureList.Add(arch);
            }

            //Удаление по Id. 
            public static void DeleteArchitecture(int id)
            {
                var foundArch = ArchitectureList.SingleOrDefault(x => x.ArchitectureId == id);
                if (foundArch != null)
                ArchitectureList.Remove(foundArch);
                else
                    throw new KeyNotFoundException("Id was not found!");
            }

            //Замена архитектуры с указанным Id друой архитектурой.
            public static void ChangeArchitecture(int id, Architecture arch)
            {
                var foundArch = ArchitectureList.SingleOrDefault(x => id == x.ArchitectureId);
                if (foundArch != null)
                {
                    arch.ArchitectureId = id;
                ArchitectureList[(ArchitectureList.IndexOf(foundArch))] = arch;
                }
                else
                    throw new KeyNotFoundException("Id was not found!");
            }            

            //получение объекта по указанному Id.
            public static Architecture GetArchitectureById(int id)
            {
                return ArchitectureList.SingleOrDefault(x => x.ArchitectureId == id);
            }        

    }
}
