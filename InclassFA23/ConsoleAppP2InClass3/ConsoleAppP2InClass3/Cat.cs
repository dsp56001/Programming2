using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ConsoleAppP2InClass3
{
    public class Cat : Mammal
    {
        public Cat()
        {
            this.Name = "Rocket";
        }

        //Associtation more Ts please
        //Uses a
        public void UseLitterBox(LitterBox box)
        {
            this.Weight--;
            box.IsClean = false;
        }
    }
}