namespace Architecture.Data.Entities
{
    public enum State
    {
        Great,
        Good,
        Normal,
        Bad,
        Awful
    }

    public class Architecture
    {
        public Architecture()
        {     
        }

        public Architecture(
            string title, 
            int creationYear,
            string country, 
            string city,
            string address,
            double square,
            double height, 
            State state, 
            int architectId, 
            int styleId)
        {
            Title = title;
            CreationYear = creationYear;
            Country = country;
            City = city;
            Address = address;
            Square = square;
            Height = height;
            State = state;
            ArchitectId = architectId;
            StyleId = styleId;
        }

        
        public int Id { get; set; }

        public string Title { get; set; }

        public int CreationYear { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public double Square { get; set; }

        public double Height { get; set; }

        public State State { get; set; }

        public int ArchitectId { get; set; }
        public Architect Architect { get; set; }

        public int StyleId { get; set; }
        public Style Style { get; set; }

        public int BuiltBy { get; set; }
        public Architect BuiltById { get; set; }

        public int RepairNeeds { get; set; }
        public Repair RepairNeedsId { get; set; }

        //еще фотка может быть
    }
}
