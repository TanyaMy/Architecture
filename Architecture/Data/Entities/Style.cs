

namespace Architecture.Data.Entities
{
    public class Style
    {
        public Style()
        {
            
        }

        public Style(
            string title,
            string motherCountry,
            string era)
        {
            Title = title;
            MotherCountry = motherCountry;
            Era = era;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string MotherCountry { get; set; }

        public string Era { get; set; }
    }
}
