

namespace Architecture.Presentation.Models
{
    public enum State
    {
        great,
        good,
        normal,
        bed,
        awful
    }

    public class Architecture
    {

        private int _architectureId;
        private string _title;
        private int _creationYear;
        private string _country;
        private string _city;
        private string _address;
        private double _square;
        private double _height;
        private int _architectId;
        private State _state;
        private int _styleId;

        public Architecture(string title, int creationYear,
            string country,  string city, string address,
            double square, double height, 
             State state, int architectId, int styleId)
        {
            _title = title;
            _creationYear = creationYear;
            _country = country;
            _city = city;
            _address = address;
            _square = square;
            _height = height;
            _state = state;
            _architectId = architectId;
            _styleId = styleId;
        }

        
        public int ArchitectureId
        {
            get { return _architectureId; }
            set { _architectureId = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public int CreationYear
        {
            get { return _creationYear; }
            set { _creationYear = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public double Square
        {
            get { return _square; }
            set { _square = value; }
        }

        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public State State
        {
            get { return _state; }
            set { _state = value; }
        }

        public int ArchitectId
        {
            get { return _architectId; }
            set { _architectId = value; }
        }

        public Architect Build_by
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Repair Needs
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

      

        //еще фотка может быть
    }
}
