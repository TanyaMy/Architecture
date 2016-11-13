using System;

namespace Architecture.Data.Entities
{
    public class Repair
    {
        public Repair()
        {
        }

        public Repair(
            RestorationKind restorationKind, 
            int architectureId,
            DateTime restorationDate, 
            double restorationCost,
            Restoration correspondsWithRestorationKind)
        {
            RestorationKind = restorationKind;
            ArchitectureId = architectureId;
            RestorationCost = restorationCost;
            RestorationDate = restorationDate;
        }

        public int Id { get; set; }

        public RestorationKind RestorationKind { get; set; }

        public int ArchitectureId { get; set; }
        public Architecture Architecture { get; set; }

        public DateTime RestorationDate { get; set; }

        public double RestorationCost { get; set; }
    }
}
