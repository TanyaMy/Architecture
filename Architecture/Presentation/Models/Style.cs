

namespace Architecture.Presentation.Models
{
    public class Style
    {

        private int _styleId;
        private string _title;
        private string _motherCountry;
        private string _era;

        public Style(string title, string era)
        {
            _title = title;
            _era = era;
        }

        public int StyleId
        {
            get { return _styleId; }
            set { _styleId = value; }
        }
    

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string MotherCountry
        {
            get { return _motherCountry; }
            set { _motherCountry = value; }
        }

        public string Era
        {
            get { return _era; }
            set { _era = value; }

        }
    }
}
