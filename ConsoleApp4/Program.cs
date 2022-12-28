using ConsoleApp4.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Write("Select an action: " +
            "1 - add" +
            " 2 - delete" +
            " 3 - output" +
            " 4 - edit\n");

                int choise = Convert.ToInt32(Console.ReadLine());
                if (choise == 1)
                {
                    Console.WriteLine("What table do you want to add data to?" +
                        " 1 - Person" +
                        " 2 - Position" +
                        " 3 - Phone");
                    int option = Convert.ToInt32(Console.ReadLine());
                    if (option == 1)
                    {
                        using (PersonContext db = new PersonContext())
                        {
                            Person p = new Person { NamePerson = "Dima" };
                            Person p2 = new Person { NamePerson = "Dima2" };
                            db.Persons.AddRange(new List<Person> { p, p2 });

                            db.SaveChanges();
                        }
                    }
                    else if (option == 2)
                    {
                        using (PersonContext db = new PersonContext())
                        {
                            Position p = new Position { PositionName = "Employer" };
                            Position p2 = new Position { PositionName = "Employee" };
                            db.Positionss.AddRange(new List<Position> { p, p2 });

                            db.SaveChanges();
                        }
                    }
                    else if (option == 3)
                    {
                        using (PersonContext db = new PersonContext())
                        {

                            Phone phn = new Phone { PhoneModel = 15 };
                            db.Phones.Add(phn);
                            Person p = new Person { NamePerson = "haha", Phone = phn };
                            db.Persons.Add(p);
                            db.SaveChanges();
                        }
                    }
                }
                else if (choise == 2)
                {
                    Console.WriteLine("In which table do you want to delete data?" +
                        " 1 - Person" +
                        " 2 - Position" +
                        " 3 - Phone");
                    int option = Convert.ToInt32(Console.ReadLine());
                    if (option == 1)
                    {
                        using (PersonContext db = new PersonContext())
                        {
                            Console.WriteLine("Add id of Person that you need to delete");
                            int person_id = Convert.ToInt32(Console.ReadLine());
                            Person del_person = db.Persons.First(p => p.PersonId == person_id);

                            foreach (Person p in db.Persons)
                            {
                                if (p.PersonId == person_id)
                                {
                                    db.Persons.Remove(p);
                                }
                            }
                            db.Persons.Remove(del_person);
                            db.SaveChanges();
                        }
                    }
                    else if (option == 2)
                    {
                        using (PersonContext db = new PersonContext())
                        {
                            Console.WriteLine("Add id of Position that you need to delete");
                            int position_id = Convert.ToInt32(Console.ReadLine());
                            Position del_pos = db.Positionss.First(p => p.PositionId == position_id);
                            db.Positionss.Remove(del_pos);
                            db.SaveChanges();
                        }
                    }
                    else if (option == 3)
                    {
                        using (PersonContext db = new PersonContext())
                        {
                            Console.WriteLine("Add id of Phone that you need to delete");
                            int phone_id = Convert.ToInt32(Console.ReadLine());
                            Phone del_phone = db.Phones.First(p => p.PhoneId == phone_id);
                            db.Phones.Remove(del_phone);
                            db.SaveChanges();
                        }
                    }

                }
                else if (choise == 3)
                {
                    Console.WriteLine("\r\nWhat table do you want to output?" +
                        " 1 - Person" +
                        " 2 - Position" +
                        " 3 - Phone");
                    int option = Convert.ToInt32(Console.ReadLine());
                    if (option == 1)
                    {

                        using (PersonContext db = new PersonContext())
                        {
                            var persons = db.Persons;
                            foreach (Person person in persons)
                            {
                                Console.WriteLine("{0} {1}", person.PersonId, person.NamePerson);
                            }
                        }
                    }
                    else if (option == 2)
                    {
                        using (PersonContext db = new PersonContext())
                        {
                            var positions = db.Positionss;
                            foreach (Position pos in positions)
                            {
                                Console.WriteLine("{0} {1}", pos.PositionId, pos.PositionName);
                            }
                        }
                    }
                    else if (option == 3)
                    {
                        using (PersonContext db = new PersonContext())
                        {
                            var phones = db.Phones;
                            foreach (Phone phone in phones)
                            {
                                Console.WriteLine("{0} {1}", phone.PhoneId, phone.PhoneModel);
                            }
                        }
                    }
                }
                else if (choise == 4)
                {
                    Console.WriteLine("Choose table for edit?" +
                        " 1 - Person" +
                        " 2 - Position" +
                        " 3 - Phone");
                    int option = Convert.ToInt32(Console.ReadLine());
                    if (option == 1)
                    {
                        Console.WriteLine("Input id for edit Person:");
                        int chooser = Convert.ToInt32(Console.ReadLine());
                        using (PersonContext db = new PersonContext())
                        {
                            Person per = db.Persons.FirstOrDefault(p => p.PersonId == chooser);
                            Console.WriteLine("Come on {0} id {1} NamePerson\n", per.PersonId, per.NamePerson);
                            Console.WriteLine("Input new NamePerson: ");
                            per.NamePerson = Console.ReadLine();
                            db.Entry(per).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    else if (option == 2)
                    {
                        Console.WriteLine("Input id for edit Position:");
                        int chooser = Convert.ToInt32(Console.ReadLine());
                        using (PersonContext db = new PersonContext())
                        {
                            Position pos = db.Positionss.First();
                            foreach (Position p in db.Positionss)
                            {
                                if (p.PositionId == chooser)
                                    pos = p;
                            }
                            Console.WriteLine("Come on {0} id {1} PositionName\n", pos.PositionId, pos.PositionName);
                            Console.WriteLine("Input new PositionName: ");
                            pos.PositionName = Console.ReadLine();
                            db.Entry(pos).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    else if (option == 3)
                    {
                        Console.WriteLine("Input id for edit Phone:");
                        int chooser = Convert.ToInt32(Console.ReadLine());
                        using (PersonContext db = new PersonContext())
                        {
                            Phone phon = db.Phones.FirstOrDefault(p => p.PhoneId == chooser);
                            if (phon != null)
                            {
                                Console.WriteLine("Come on {0} id {1} PhoneModel\n", phon.PhoneId, phon.PhoneModel);
                                Console.WriteLine("Input new PhoneModel(type - int): ");
                                phon.PhoneModel = Convert.ToInt32(Console.ReadLine());
                                db.Entry(phon).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                    }
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }
    }
}
