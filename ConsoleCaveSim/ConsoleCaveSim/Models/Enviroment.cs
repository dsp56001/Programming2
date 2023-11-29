using ConsoleCaveSim.Models.Consumers;
using ConsoleCaveSim.Models.Producers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCaveSim.Models
{
    public abstract class Enviroment : Entity
    {

        #region Methods

        public Enviroment()
        {
            this.Name = "Enviroment #" + this.Id;
            this.Description = "This an Enviroment";
            this.Items = new List<IEntity>();

            this.itemsToRemove = new List<IEntity>();
            this.itemsToAdd = new List<IEntity>();
        }

        public override string About()
        {
            string EnvAbout = base.About();
            EnvAbout += "\nItems-------------";
            foreach (var entity in this.Items)
            {
                
                if(!(entity is Corn))
                {
                    EnvAbout += "\n" + entity.About();
                }
            }
            EnvAbout += "\nCorn Count " + this.Items.Select(i => i.Name == "Corn").Count().ToString();
            return EnvAbout;
        }

        public void Add(IEntity entity)
        {
            this.Items.Add(entity);
        }

        List<IEntity> itemsToAdd;
        List<IEntity> itemsToRemove;
        public void Tick()
        {
            itemsToAdd.Clear();
            itemsToRemove.Clear();
            
            for (int i = 0; i < this.Items.Count; i++)
            {
                
                if(this.Items[i] is Producer)
                {
                    //Producers gonna produce
                    if(this.Items[i] is Corn)
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
                        if(c != null)
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

        #endregion

        #region Items

        public List<IEntity> Items { get; set; }

        #endregion
    }
}
