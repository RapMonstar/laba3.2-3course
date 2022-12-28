using System;
using System.Data.Entity;
using System.Linq;

namespace ConsoleApp4.Data
{
    public class PersonContext : DbContext
    {
        public PersonContext()
            : base("name=PersonContext")
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Position> Positionss { get; set; }
    }

}