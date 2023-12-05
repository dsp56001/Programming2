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

        public void AddItemsToAdd(IEntity itemToAdd)
        {
            this.itemsToAdd.Add(itemToAdd);
        }

        public override string About()
        {
            string EnvAbout = base.About();
            EnvAbout += "\nItems -------------";
            foreach (var entity in this.Items)
            {
                EnvAbout += "\n" + entity.About();
            }
            
            return EnvAbout;
        }

        public void Add(IEntity entity)
        {
            this.Items.Add(entity);
        }

        

        #endregion

        #region Items

        public List<IEntity> Items { get; set; }

        #endregion
    }
}
