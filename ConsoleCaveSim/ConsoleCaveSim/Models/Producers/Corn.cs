using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCaveSim.Models.Producers
{
    public class Corn : Producer
    {

        static string desc = "some descrition";
        static string name = "Corn";

        public Corn() 
        {
            this.Name = name;
            this.Description = desc;
        }

        public override IEntity Produce()
        {
            //Cast the IEntity to a Corn
            return (Corn)base.Produce();
        }

    }
}
