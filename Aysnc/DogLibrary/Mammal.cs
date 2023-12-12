using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DogLibrary
{
    public abstract class Mammal : IMammal
    {
        public int Id
        {
            get;
            protected set;

        }

        public int Age
        {
            get;
            protected set;
            
        }

        public string Sound
        {
            get;
            protected set;
            
        }

        public string Name
        {
            get;
            set;
            
        }

        public int Weight
        {
            get;
            set;
            
        }

        public Mammal() : this("Mammal") { }
        public Mammal(string Name) : this(Name, 1,2, "sound") { }
        public Mammal (string Name, int Age, int Weight, string Sound)
        {
            this.Age = Age;
            this.Weight = Weight;
            this.Sound = Sound;
            this.Name = Name;
        }
        
        public virtual string MakeSound()
        {
            return this.Sound;
        }

        public virtual int HappyBirthday()
        {
            return this.Age++;
        }

        public void Eat()
        {
            this.Weight++;
        }

        public virtual string About()
        {
            return string.Format($"I'm a {this} I'm {Age} old and I weigh {Weight} lbs. I sound like {Sound}");
        }
    }
}