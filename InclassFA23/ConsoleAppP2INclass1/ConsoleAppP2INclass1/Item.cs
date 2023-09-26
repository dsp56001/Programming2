using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppP2INclass1
{
    public class Item
    {
        public string Name;
        public string Description;

        public Item()
        {
            this.Name = "Item Name";
            this.Description = "Item Descrition";
        }

        public virtual string About()
        {
            return $"Name : {this.Name} \t Description : {this.Description}";
        }
    }
}