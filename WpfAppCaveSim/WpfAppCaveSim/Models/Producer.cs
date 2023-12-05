using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCaveSim.Models
{
    public class Producer : Entity
    {

        protected Enviroment Enviroment;

        public Producer(Enviroment env) 
        { 
            this.Enviroment = env;
        }

        public virtual void Produce()
        {
            //This is temporary this Proucer makes another on of itself.
            //Its a Virus
            
        }
    }
}
