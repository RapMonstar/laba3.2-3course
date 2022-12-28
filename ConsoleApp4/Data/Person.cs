using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Data
{
    public class Person
    {
        public int PersonId { get; set; }
        public string NamePerson { get; set; }


        public int? PhoneId { get; set; }
        public Phone Phone { get; set; }


        public ICollection<Position> Positions { get; set; }
        public Person()
        {
            Positions = new List<Position>();
        }
    }
}
