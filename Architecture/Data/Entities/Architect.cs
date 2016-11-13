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
            DateTime birthDate,
            DateTime deathDate)
        {
            Name = name;
            Surname = surname;
            Nationality = nationality;
            BirthDate = birthDate;
            DeathDate = deathDate;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Nationality { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime DeathDate { get; set; }


        public int WorksInId { get; set; }
        public Style WorksIn { get; set; }

        //еще фотка
    }
}
