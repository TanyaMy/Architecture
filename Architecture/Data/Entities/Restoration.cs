

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

        public int Id { get; set; }

        public RestorationKind RestorationKind { get; set; }

        public string Periodicity { get; set; }

        public double Outlays { get; set; }
    }
}
