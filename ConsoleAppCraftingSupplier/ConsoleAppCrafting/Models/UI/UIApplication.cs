using ConsoleAppCrafting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCrafting.UI
{
    internal class UIApplication
    {
        FoodColoringRecipes recipes;
        public FoodColoringRecipes Recipes { get => recipes; set => recipes = value; }

        public DyeSupplier Supplier;
        public Customer Customer;

        public UIApplication()
        {
            recipes = new FoodColoringRecipes();
            Supplier = new DyeSupplier();
            Customer = new Customer();
        }

        internal void Test()
        {
            this.Customer.AddItemToInventory(this.Supplier.GetItem("Yellow Coloring"));
            this.Customer.AddItemToInventory(this.Supplier.GetItem("Yellow Coloring"));
            this.Customer.AddItemToInventory(this.Supplier.GetItem("Blue Coloring"));

            Console.WriteLine(this.Customer.About());

            string craftingMessage = string.Empty;

            this.Customer.MoveItemToCraftingItemsFromInveroty("Yellow Coloring");
            craftingMessage = this.Customer.Craft(this.Supplier.GetRecipe("Yellow Dye Recipe"));
            Console.WriteLine(craftingMessage);

            Console.WriteLine(this.Customer.About());

            this.Customer.MoveItemToCraftingItemsFromInveroty("Yellow Coloring");
            this.Customer.MoveItemToCraftingItemsFromInveroty("Blue Coloring");
            craftingMessage = this.Customer.Craft(this.Supplier.GetRecipe("Green Dye Recipe"));
            Console.WriteLine(craftingMessage);

            Console.WriteLine(this.Customer.About());
        }
    }
}
