using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppP2INclass1
{
    public class Person
    {

        public string FirstName;
        public string LastName;
        public int Currency;

        public Cat cat;

        public Person()
        {
            this.cat = new Cat();
            this.FirstName = "default firstName";
            this.LastName = "default lastName";
        }

        public string SayHello()
        {
            return "Hello," + this.FirstName + "!";
        }

        public string SayGoodbye()
        {
            return $"Goodbye {this.FirstName}";
        }

    }
}
