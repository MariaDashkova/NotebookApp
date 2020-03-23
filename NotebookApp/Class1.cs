using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class Note
    {
        public int Id { get; private set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Number { get; set; }
        public string Country { get; set; }
        public DateTime Birthday { get; set; }
        public string Org { get; set; }
        public string Specialty { get; set; }
        public string Addition{ get; set; }

        public Note(string surname, string name, string number, string country)
        {
            Surname = surname;
            Name = name;
            Number = number;
            Country = country;
            Id = GetHashCode();
        }

        public override int GetHashCode()
        {
            return Surname.GetHashCode()+Name.GetHashCode();
        }

        public void newId()
        {
            this.Id = this.Surname.GetHashCode() + this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return "Surname: " + this.Surname + "\n"+
                "Name: " + this.Name + "\n" +
                "Number: " + this.Number; 
        }

    }
}
