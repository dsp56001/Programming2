using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogLibrary
{
    public class Dog : Mammal
    {
        public string BarkSound
        {
            get
            {
                return this.Sound;
            }

            set
            {
                //Set sound 
                this.Sound = value;
            }
        }

        public static int DogCount; //Count of all dogs ever created


        public Dog() : this("fido", 1, 2, "woof")
        {

        }

        public Dog(string Name, int Age, int Weight, string BarkSound)
        {   
            this.Name = Name;
            this.Sound = BarkSound;
        }



        /// <summary>
        /// This barks the dog 
        /// </summary>
        /// <returns>The bark sound</returns>
        public string Bark()
        {
            return this.BarkSound;
        }

        /// <summary>
        /// Barks the Dog more than once
        /// </summary>
        /// <param name="HowManyTimes">How many times to bak the dog</param>
        /// <returns></returns>
        public string Bark(int HowManyTimes)
        {
            string barks = "";
            for (int i = 0; i < HowManyTimes; i++)
            {
                barks += this.Bark() + " ";
            }
            barks = barks.Trim();
            return barks;
        }

        public string About()
        {
            return $"Hello my name is {this.Name} I'm {this.Age} year old and my Bark sound like {this.Bark()}";
        }
    }
}
