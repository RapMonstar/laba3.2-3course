using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Data
{
    public class Position
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public ICollection<Person> Persons { get; set; }

        public Position()
        {
            Persons = new List<Person>();
        }
    }
}
