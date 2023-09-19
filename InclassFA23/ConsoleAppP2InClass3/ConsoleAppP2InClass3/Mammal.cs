using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppP2InClass3
{
    public class Mammal
    {
        public bool hasHair;
        public bool giveBrithToLiveYoung;

        public string Name;
        public int Weight;

        //Same name as the class and no return type
        //sets defaults
        public Mammal()
        {
            this.Name = "some mammal maybe a platapus";
            this.hasHair = true;
            this.giveBrithToLiveYoung = true;
            this.Weight = 2;
        }

        public virtual string About()
        {
            return $"Hello I'm a {this}  My name is {this.Name} I weight {this.Weight} ";
        }
    }
}