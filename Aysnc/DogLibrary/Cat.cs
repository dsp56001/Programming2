using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DogLibrary
{
    public class Cat : Mammal
    {
        public int MeowSound
        {
            get;
            set;
        }

        public string Meow()
        {
            return this.MakeSound();
        }
    }
}