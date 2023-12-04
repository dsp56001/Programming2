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
        protected Enviroment enviroment;
        
        public Bat(Enviroment env) 
        { 
            this.Name = "Bat " +this.Id;
            this.Description = "Bats eat corn";
            this.Hunger = 100; //Not sure how hungry bats are
            this.enviroment = env;
        }

        public override void Consume(IEntity entity)
        {
            if(entity is Corn)
            {
                this.Hunger--;

                Corn c = ((Corn)entity);
                c.State = CornState.Consumed;
            }
            base.Consume(entity);
        }

        public override string About()
        {
            return base.About() + $" hunger : {this.Hunger}";
        }

        public override void Tick()
        {
            base.Tick();

            Corn? c = (Corn)enviroment.Items.FirstOrDefault(c => c.Name == "Corn")!;
            if (c is not null)
            {
                //Eat the corn
                this.Consume(c);
            }
            else
            {
                this.Hunger++;
            }
        }

    }
}
