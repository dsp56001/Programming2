using ConsoleCaveSim.Models.Producers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCaveSim.Models.Consumers
{
    public class Bat : Consumer
    {
        public int Hunger;
        
        public Bat() 
        { 
            this.Name = "Bat " +this.Id;
            this.Description = "Bats eat corn";
            this.Hunger = 100; //Not sure how hungry bats are
        }

        public override void Consume(IEntity entity)
        {
            if(entity is Corn)
            {
                this.Hunger--;
            }
            base.Consume(entity);
        }

        public override string About()
        {
            return base.About() + $" hunger : {this.Hunger}";
        }

    }
}
