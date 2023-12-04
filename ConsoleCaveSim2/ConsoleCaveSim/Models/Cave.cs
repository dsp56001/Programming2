using ConsoleCaveSim.Models.Consumers;
using ConsoleCaveSim.Models.Producers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            foreach(var item in Items)
            {
                item.Tick();
                if (item is Producer)
                {
                    //Producers gonna produce
                    if (item is Corn)
                    {
                        Corn c = (Corn)item;
                        //if we have corn produce more corn
                        itemsToAdd.Add(c.Produce());
                        
                        
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
