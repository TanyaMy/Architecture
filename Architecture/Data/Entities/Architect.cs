using System;

namespace Architecture.Data.Entities
{
    public class Architect
    {
        public Architect()
        {
        }

        public Architect(
            string name, 
            string surname, 
            string nationality,
            int birthYear,
            int deathYear)
        {
            Name = name;
            Surname = surname;
            Nationality = nationality;
            BirthYear = birthYear;
            DeathYear = deathYear;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Nationality { get; set; }

        public int BirthYear { get; set; }

        public int DeathYear { get; set; }
 
    }
}
