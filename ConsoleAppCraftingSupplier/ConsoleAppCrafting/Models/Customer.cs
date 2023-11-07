using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCrafting.Models
{
    public class Customer
    {
        List<IItem> inventoryItems;     //Private instance data mamber

        public List<IItem> InventoryItems { get => inventoryItems; set => inventoryItems = value; }

        List<IItem> craftItems;         //Private instance data mamber

        public List<IItem> CraftItems { get => craftItems; set => craftItems = value; }

        decimal Money;
        public Customer()
        {
            this.inventoryItems = new List<IItem>();
            this.craftItems = new List<IItem>();
            this.Money = 2;
        }

        /// <summary>
        /// Add an Item to inventory
        /// </summary>
        /// <param name="item"></param>
        public void AddItemToInventory(IItem item)
        {
            this.inventoryItems.Add(item);
        }

        /// <summary>
        /// Move Item from Inventory to CraftingItems
        /// </summary>
        /// <param name="ItemsName"></param>
        public void MoveItemToCraftingItemsFromInveroty(string ItemsName)
        {
            var item = this.inventoryItems.Where(i => i.Name.Contains(ItemsName)).FirstOrDefault<IItem>();
            if (item != null)
            {
                this.craftItems.Add(item);
                this.inventoryItems.Remove(item);
            }
        }

        public void MoveItemToInventoryFromCraftingItems(string ItemsName)
        {
            var item = this.CraftItems.Where(i => i.Name.Contains(ItemsName)).FirstOrDefault<IItem>();
            if (item != null)
            {
                this.InventoryItems.Add(item);
                this.CraftItems.Remove(item);
            }
        }

        /// <summary>
        /// Determines if the current inventory and craftInventory can craft a recipe
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns>Returns true if the current Inventory Items Can Craft the Recipe</returns>
        public bool CanCraft(IRecipe recipe)
        {
            try
            {
                //allItems is inventoryItems and craftItems
                List<IItem> allItems = new List<IItem>();
                foreach (var item in inventoryItems)
                {
                    allItems.Add(item);
                }
                foreach (var item in craftItems)
                {
                    allItems.Add(item);
                }
                recipe.MakeRecipe(allItems);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public string Craft(IRecipe recipe)
        {
            return this.craft(recipe, this.craftItems);
        }

        protected string craft(IRecipe recipe, List<IItem> sourceItems)
        {
            IItem item;
            try
            {
                item = this.makeRecipe(recipe, sourceItems);
                //remove items from craftItems
                while (sourceItems.Count > 0)
                {
                    this.craftItems.Remove(sourceItems[0]);
                }
                this.inventoryItems.Add(item);
                return $"{item.Name} crafted and added to inventory";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private IItem makeRecipe(IRecipe recipe, List<IItem> items)
        {
            return recipe.MakeRecipe(items);
        }

        public string About()
        {
            return $"{AboutIventory()}\n{AboutCraftItems()}\ninventory value:{AboutValue():c}\nmoney:{Money:c}";
        }

        public decimal AboutValue()
        {
            decimal totalMoney = 0;
            foreach (var item in this.inventoryItems)
            {
                totalMoney += item.Price;
            }
            return totalMoney;
        }

        public string AboutIventory()
        {
            string AboutItemsString = "Inventory\n---------------------------------------\n";
            foreach (var item in this.inventoryItems)
            {
                AboutItemsString += item.About();
            }
            return AboutItemsString;
        }

        public string AboutCraftItems()
        {
            string AboutItemsString = "Craft Items\n---------------------------------------\n";
            foreach (var item in this.craftItems)
            {
                AboutItemsString += item.About();
            }
            return AboutItemsString;
        }
    }
}
