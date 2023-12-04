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
    public abstract class Enviroment : Entity , ITickable
    {
        #region Properties
        public int LifeTimeTicks { get; protected set; }
        #endregion

        #region Methods

        protected List<IEntity> itemsToAdd;
        protected List<IEntity> itemsToRemove;



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

        public virtual void Tick()
        {
            this.LifeTimeTicks += 1;

        }

        #endregion

        #region Items

        public List<IEntity> Items { get; set; }

        #endregion
    }
}
