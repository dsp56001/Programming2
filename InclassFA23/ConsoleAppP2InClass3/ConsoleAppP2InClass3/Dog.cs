using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppP2InClass3
{
    public class Dog : Mammal
    {
        
        public string BarkSound;
        
        protected int barkCount;

        public Dog()
        {
            this.Name = "fido";
            this.BarkSound = "woof!";
            
        }

        public override string About()
        {
            return base.About() + $" my bark sounds like {this.Bark()}"; ;
        }

        public virtual string Bark()
        {
            this.barkCount++;
            return this.BarkSound;

        }
    }
}