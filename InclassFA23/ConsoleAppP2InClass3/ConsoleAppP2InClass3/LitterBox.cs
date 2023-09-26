using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleAppP2InClass3
{
    public class LitterBox
    {
        public bool IsClean;

        public LitterBox()
        {
            this.IsClean = true;
        }

        public string About()
        {
            string aboutString = "LitterBox is clean";
            if (this.IsClean == true)
            {
                return aboutString;
            }

            return aboutString.Replace("is", "is not");
        }
    }
}