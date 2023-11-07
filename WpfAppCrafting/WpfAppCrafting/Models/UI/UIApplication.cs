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

            Customer.AddToCraftingItem("Yellow Coloring");
            craftingMessage = Customer.Craft(Supplier.GetRecipe("Yellow Dye Recipe"));
            Console.WriteLine(craftingMessage);

            Console.WriteLine(Customer.About());

            Customer.AddToCraftingItem("Yellow Coloring");
            Customer.AddToCraftingItem("Blue Coloring");
            craftingMessage = Customer.Craft(Supplier.GetRecipe("Green Dye Recipe"));
            Console.WriteLine(craftingMessage);

            Console.WriteLine(Customer.About());
        }

        public void GiveThreeItems()
        {
            Customer.GiveItem(Supplier.GetIngredient("Yellow Coloring"));
            Customer.GiveItem(Supplier.GetIngredient("Yellow Coloring"));
            Customer.GiveItem(Supplier.GetIngredient("Blue Coloring"));
        }
    }
}
