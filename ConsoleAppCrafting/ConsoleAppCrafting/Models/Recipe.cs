using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCrafting.Models
{
    
    public class Recipe : IRecipe
    {
        public List<IItem> Ingredients { get; set; }
        public float YieldAmount { get; set; }
        public string YieldName { get; } //ignore
        public IItem YieldItem { get; set; }    
        public string Name { get; set; }
        public string Description { get; set; }

        public Recipe()
        {
            this.Ingredients = new List<IItem>();
            this.YieldItem = new Item();
            this.YieldAmount = 1f;
            this.Name = "Item Name";
            this.YieldName = "Name";
            this.Description = "Item Description";

            
        }

        public string About()
        {
            string AboutString = $"Recipe ---------------------------\n";
            AboutString += $"Name:\t\t{this.Name}\n";
            AboutString += $"Desciption:\t\t{this.Description}\n";
            AboutString += $"YieldAmount:\t\t{this.YieldAmount:G}\n";
            AboutString += $"Yield Item------------\n";

            AboutString += $"{this.YieldItem.About()}\n";
            AboutString += $"Ingredients ----------------------------\n";
            foreach ( var ingredient in Ingredients )
            {
                AboutString += ingredient.About();
            }
            return AboutString;
        }

        public IItem MakeRecipe(List<IItem> sourceItems)
        {
            List<IItem> requiredItems = this.Ingredients.ToList();
            
            foreach (var item in sourceItems)
            {
                IItem FoundItem = new Item();
                foreach (var ri in requiredItems) 
                { 
                    if(item.Name == ri.Name) { FoundItem = ri; break; }
                }
                if(FoundItem != null)
                {
                    requiredItems.Remove(FoundItem);
                }  
            }

            if(requiredItems.Count != 0)
            {
                throw new Exception($"{this.Name} source Items do not make  {YieldItem.Name}");
            }
            return YieldItem;
        }
    }
}
