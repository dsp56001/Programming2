using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCaveSim.Models
{
    public class Cave : Enviroment
    {
        public Cave() 
        {
            this.Name = "Cave #" + this.Id;
            this.Description = "I like Caves!!!"; //just having fun TODO fix this
        }
    }
}
