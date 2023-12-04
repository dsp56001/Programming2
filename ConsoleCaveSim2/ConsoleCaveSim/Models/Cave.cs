using ConsoleCaveSim.Models.Consumers;
using ConsoleCaveSim.Models.Producers;
using System;
using System.Collections.Generic;
using System.Data;
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

        
        public override void Tick()
        {
            base.Tick();

            itemsToAdd.Clear();
            itemsToRemove.Clear();

            for (int i = 0; i < this.Items.Count; i++)
            {

                if (this.Items[i] is Producer)
                {
                    //Producers gonna produce
                    if (this.Items[i] is Corn)
                    {
                        //if we have corn produce more corn
                        itemsToAdd.Add(((Corn)this.Items[i]).Produce());
                    }
                }

                if (this.Items[i] is Consumer)
                {
                    //Consumers gonna consume
                    if (this.Items[i] is Bat)
                    {

                        Bat b = (Bat)this.Items[i];
                        //bats eat corn
                        Corn c = (Corn)this.Items.Where(c => c.Name == "Corn").FirstOrDefault();
                        if (c != null)
                        {
                            //Eat the corn
                            b.Consume(c);
                            itemsToRemove.Add(c);
                        }
                        else
                        {
                            b.Hunger++;
                        }

                    }
                }
            }

            //Add new items
            foreach (var item in itemsToAdd)
            {
                this.Items.Add(item);
            }
            //Remove remove items
            foreach (var item in itemsToRemove)
            {
                this.Items.Remove(item);
            }
        }
    }
}
