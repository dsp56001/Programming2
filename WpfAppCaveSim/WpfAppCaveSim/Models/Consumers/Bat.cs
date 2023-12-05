using ConsoleCaveSim.Models.Producers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCaveSim.Models.Consumers
{
    
    public enum BatState { Happy, Hungry, NotLiving, Full }
    
    public class Bat : Consumer
    {
        public int HungerLevel { get; set; }
        public int CurrentHunger { get; set; }
        protected Enviroment enviroment;
        public BatState State { get; set; }

        Random rand;
        
        public Bat(Enviroment env) 
        { 
            this.Name = "Bat " +this.Id;
            this.Description = "Bats eat corn";
            this.HungerLevel = 100; //Not sure how hungry bats are
            this.enviroment = env;
            this.State = BatState.Happy;
            
            rand = new Random();
        }

        public override void Consume(IEntity entity)
        {
            if(entity is Corn)
            {
                if(this.HungerLevel > 0)
                    this.HungerLevel--;

                Corn c = ((Corn)entity);
                c.State = CornState.Consumed;
            }
            base.Consume(entity);
        }

        public override string About()
        {
            return base.About() + $" hunger : {this.HungerLevel}";
        }

        public override void Tick()
        {
            base.Tick();
            UpdateState();
            this.CurrentHunger = Math.Min(rand.Next(10), HungerLevel);
            var corns = this.enviroment.Items.OfType<Corn>().ToList();
            //Eat the corn
            int hungerCount = this.CurrentHunger;
            if (hungerCount >= corns.Count) { hungerCount = corns.Count; }
            do
            {
                Corn c = corns.FirstOrDefault(c => c.State == CornState.Good)!;
                if (c is not null)
                {
                    this.Consume(c);
                }
                else
                {
                    this.HungerLevel++;
                }
                hungerCount--;
            }while(hungerCount > 0);
        }

        private void UpdateState()
        {

            if (HungerLevel > 100)
            {
                this.State = BatState.Hungry;
            }
            if (HungerLevel > 20)
            {
                this.State = BatState.Happy;
            }
            if (HungerLevel == 0)
            {
                this.State = BatState.Full;
            }
            
            
        }
    }
}
