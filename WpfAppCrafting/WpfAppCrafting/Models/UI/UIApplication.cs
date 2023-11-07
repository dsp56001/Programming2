using ConsoleAppCrafting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppCrafting.Models.UI
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
            GiveThreeItems();

            Console.WriteLine(Customer.About());

            string craftingMessage = string.Empty;

            Customer.MoveItemToCraftingItemsFromInveroty("Yellow Coloring");
            craftingMessage = Customer.Craft(Supplier.GetRecipe("Yellow Dye Recipe"));
            Console.WriteLine(craftingMessage);

            Console.WriteLine(Customer.About());

            Customer.MoveItemToCraftingItemsFromInveroty("Yellow Coloring");
            Customer.MoveItemToCraftingItemsFromInveroty("Blue Coloring");
            craftingMessage = Customer.Craft(Supplier.GetRecipe("Green Dye Recipe"));
            Console.WriteLine(craftingMessage);

            Console.WriteLine(Customer.About());
        }

        public void GiveThreeItems()
        {
            Customer.AddItemToInventory(Supplier.GetItem("Yellow Coloring"));
            Customer.AddItemToInventory(Supplier.GetItem("Yellow Coloring"));
            Customer.AddItemToInventory(Supplier.GetItem("Blue Coloring"));
        }
    }
}
