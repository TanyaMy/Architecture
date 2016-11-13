

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Architecture.Data.Entities
{
    public enum RestorationKind
    {

    }

    public class Restoration
    {
        public Restoration()
        {       
        }

        public Restoration( 
            RestorationKind restoration, 
            string periodicity,
            double outlays)
        {
            RestorationKind = restoration;
            Periodicity = periodicity;
            Outlays = outlays;
        }

        [Key]
        public RestorationKind RestorationKind { get; set; }

        public string Periodicity { get; set; }

        public double Outlays { get; set; }

        public IList<Repair> Repairs { get; set; }
    }
}
