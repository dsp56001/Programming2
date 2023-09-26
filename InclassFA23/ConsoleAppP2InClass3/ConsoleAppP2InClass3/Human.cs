using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppP2InClass3
{
    public class Human : Mammal
    {
        //Has a containment
        public Cat cat;

        /// <summary>
        /// Eveny human gets a cat called Rocket
        /// </summary>
        public Human() 
        {
            this.cat = new Cat();
        }

        /// <summary>
        /// Give this human a specific cat
        /// </summary>
        /// <param name="cat">Cat to give the human</param>
        public Human(Cat cat)
        {
            this.cat = cat;
        }

        

        
    }
}