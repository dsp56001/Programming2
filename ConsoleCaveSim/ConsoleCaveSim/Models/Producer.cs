using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCaveSim.Models
{
    public class Producer : Entity
    {
        public Producer() { }

        public virtual IEntity Produce()
        {
            //This is temporary this Proucer makes another on of itself.
            //Its a Virus
            return this;
        }
    }
}
