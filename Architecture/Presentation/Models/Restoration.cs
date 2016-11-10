

namespace Architecture.Presentation.Models
{
    public enum RestorationKind
    {

    }

    public class Restoration
    {
        private RestorationKind _restorationKind;
        private string _periodicity;
        private double _outlays;

        public Restoration( RestorationKind restoration, string periodicity,
            double outlays)
        {
            _restorationKind = restoration;
            _periodicity = periodicity;
            _outlays = outlays;
        }

        public RestorationKind RestorationKind
        {
            get { return _restorationKind; }
            set { _restorationKind = value; }
        }

        public string Periodicity
        {
            get { return _periodicity; }
            set { _periodicity = value; }
        }

        public double Outlays
        {
            get { return _outlays; }
            set { _outlays = value; }
        }
    }
}
