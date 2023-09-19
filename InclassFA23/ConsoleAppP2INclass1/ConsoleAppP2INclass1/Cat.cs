using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppP2INclass1
{
    public class Cat : Item
    {
        
        public int Age;

        //constuctor
        public Cat()
        {
            this.Name = "Bella";
            this.Age = 21;
        }

        public override string About()
        {
            return base.About() + $" Age : {this.Age}";
        }
    }
}