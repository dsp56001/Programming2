using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppP2InClass3
{
    public class Basenji : Dog
    {
        public Basenji() 
        {
            this.BarkSound = "Basenjis dont bark they hown and growl";
        }

        public override string Bark()
        {
            //return base.Bark(); //don't to prarent
            return "Basenjis dont bark they hown and growl";
        }
    }
}