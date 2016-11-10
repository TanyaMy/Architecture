using System;


namespace Architecture.Presentation.Models
{
    public class Architect
    {

        private int _arcitectId;
        private string _name;
        private string _surname;
        private DateTime _birthDate;
        private DateTime _deathDate;
        private string _nationality;

        public Architect(string name, string surname, string nationality,
            DateTime birthDate, DateTime deathDate)
        {
            _name = name;
            _surname = surname;
            _nationality = nationality;
            _birthDate = birthDate;
            _deathDate = deathDate;
        }

        public int ArchitectId
        {
            get { return _arcitectId; }
            set { _arcitectId = value; }
        }
    
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public DateTime DeathDate
        {
            get { return _deathDate; }
            set { _deathDate = value; }
        }

        public Style Works_in
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }



        //еще фотка
    }
}
