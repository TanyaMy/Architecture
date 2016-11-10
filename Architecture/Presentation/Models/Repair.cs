using System;


namespace Architecture.Presentation.Models
{
    public class Repair
    {
        private RestorationKind _restorationKind;
        private int _architectureId;
        private DateTime _lastRestorationDate;
        private double _lastRestorationCost;

        public Repair( RestorationKind restorationKind, int architectureId,
            DateTime lastRestorationDate, double lastRestorationCost)
        {
            _restorationKind = restorationKind;
            _architectureId = architectureId;
            _lastRestorationCost = lastRestorationCost;
            _lastRestorationDate = lastRestorationDate;
        }

        public RestorationKind RestorationKind
        {
            get { return _restorationKind; }
            set { _restorationKind = value; }
        }

        public int ArchitectureId
        {
            get { return _architectureId; }
            set { _architectureId = value; }
        }

        public DateTime LastRestorationDate
        {
            get { return _lastRestorationDate; }
            set { _lastRestorationDate = value; }
        }

        public double LastRestorationCost
        {
            get { return _lastRestorationCost; }
            set { _lastRestorationCost = value; }
        }

        public Restoration Corresponds_with_RestorationKind
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}
