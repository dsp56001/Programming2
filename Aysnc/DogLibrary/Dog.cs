using System;
using System.Collections.Generic;
using System.Text;

namespace DogLibrary
{
    public class Dog : Mammal
    {
        
        public string BarkSound
        {
            get
            {
                return this.Sound;  //same as mammal sound
            }

            set
            {
                //Set sound 
                this.Sound = value;
            }
        }

        public static int DogCount; //Count of all dogs ever created


        public Dog() : this("fido", 1, 2, "woof!")
        {

        }

        public Dog(string Name, int Age, int Weight, string BarkSound)
        {
            this.Age = Age;
            this.Weight = Weight;
            this.BarkSound = BarkSound;
            this.Name = Name;
            DogCount++;
        }

        

        /// <summary>
        /// Make the dog bark
        /// </summary>
        /// <returns></returns>
        public virtual string Bark()
        {
            return this.BarkSound;
        }

        /// <summary>
        /// Barks the Dog more than once
        /// </summary>
        /// <param name="HowManyTimes">How many times to bak the dog</param>
        /// <returns></returns>
        public virtual string Bark(int HowManyTimes)
        {
            string barkstring = string.Empty;
            for (int i = 0; i < HowManyTimes; i++)
            {
                barkstring += this.Bark() + " ";
            }
            return barkstring.Trim(); //trim cleans off any trailing spaces.
        }

        

        public override string About()
        {
            return base.About();
        }
    }
}
