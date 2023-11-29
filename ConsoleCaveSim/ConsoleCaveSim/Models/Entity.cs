using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCaveSim.Models
{
    public abstract class Entity :  IEntity, IAboutable
    {
        #region Properties

        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }

        #endregion
        //Static means it belongs to class and not an instance of the class
        //protected means abvailable to itself or child classes
        protected static int entCount;  // = 0

        #region Methods

        /// <summary>
        /// Constructor special method with the same name as the class and no return type
        /// </summary>
        public Entity()
        {
            this.Id = ++Entity.entCount; //Add one to the count for each entity
            this.Name = "Entitiy " + this.Id; //just for fun add the ID to the name
            this.Description = "Entity Description";
        }
        

        public virtual string About()
        {
            return $"{this.Name} {this.Description}";
        }

        #endregion

    }
}
