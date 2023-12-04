using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCaveSim.Models.Producers
{
    
    public enum CornState { Good, Consumed, Expired }

    public class Corn : Producer
    {

        static string desc = "some descrition";
        static string name = "Corn";

        public CornState State;

        public Corn() 
        {
            this.Name = name;
            this.Description = desc;
            this.State = CornState.Good;
        }

        public override IEntity Produce()
        {
            //Cast the IEntity to a Corn
            return (Corn)base.Produce();
        }

    }
}
