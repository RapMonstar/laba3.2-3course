using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Data
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public int PhoneModel { get; set; }

        public ICollection<Phone> Phones { get; set;}

    }
}
