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
        public const int GoodLifeSpan = 3;
        public const int ProducePercent = 40;
        static Random rand = new Random();

        public Corn(Enviroment env) : base(env) 
        {
            this.Name = name;
            this.Description = desc;
            this.State = CornState.Good;
        }

        public override void Produce()
        {
            if (rand.Next(100) <= ProducePercent)
            {
                //not virus new corn
                this.Enviroment.AddItemsToAdd(new Corn(this.Enviroment));
            }
            
        }
        public override void Tick()
        {
            base.Tick();
            switch(State)
            {
                case CornState.Good:
                    this.Produce();
                    //End Life if expired
                    if (this.LifeTimeTicks > GoodLifeSpan)
                    {
                        this.State = CornState.Expired;
                    }
                    break;
                case CornState.Expired:
                case CornState.Consumed:
                    break;
            }
        }

    }
}
