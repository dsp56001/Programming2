using ConsoleAppCrafting.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppCrafting.Models.UI
{
    internal class UIApplcationTester
    {

        public FoodColoringRecipes Recipes { get => Recipes; set => Recipes = value; }
        public List<IItem> Items { get => Items; set => Items = value; }


        FoodColoringRecipes recipes;
        List<IItem> items;

        public UIApplcationTester()
        {
            recipes = new FoodColoringRecipes();
            items = new List<IItem>();

            setupItems();
            setupRecipes();
            setupMakeRecipes();
        }

        protected void setupItems()
        {

            IItem yellowColoring;
            IItem redColoring;
            IItem blueColoring;

            //Ingredients
            yellowColoring = new Item() { Name = "Yellow Coloring", Description = "Yellow stuff" };
            redColoring = new Item() { Name = "Red Coloring", Description = "Red stuff" };
            blueColoring = new Item() { Name = "Blue Coloring", Description = "Blue stuff" };
            items.Add(yellowColoring);
            items.Add(redColoring);
            items.Add(blueColoring);

        }

        protected void setupRecipes()
        {
            Recipe YellowDyeRecipe;
            Recipe RedDyeRecipe;
            Recipe BlueDyeRecipe;
            Recipe GreenDyeRecipe;

            IItem yellowColoring;
            IItem redColoring;
            IItem blueColoring;

            //Ingredients
            yellowColoring = new Item() { Name = "Yellow Coloring", Description = "Yellow stuff" };
            redColoring = new Item() { Name = "Red Coloring", Description = "Red stuff" };
            blueColoring = new Item() { Name = "Blue Coloring", Description = "Blue stuff" };


            FoodColoringRecipes recipes = new FoodColoringRecipes();
            YellowDyeRecipe = recipes.Recipes.Where(r => r.Name == "Yellow Dye Recipe").First();
            RedDyeRecipe = recipes.Recipes.Where(r => r.Name == "Red Dye Recipe").First();
            BlueDyeRecipe = recipes.Recipes.Where(r => r.Name == "Blue Dye Recipe").First();
            GreenDyeRecipe = recipes.Recipes.Where(r => r.Name == "Green Dye Recipe").First();
            this.recipes = recipes;
        }

        public void setupMakeRecipes()
        {

            IItem yellowColoring;
            IItem redColoring;
            IItem blueColoring;

            //Ingredients
            yellowColoring = new Item() { Name = "Yellow Coloring", Description = "Yellow stuff" };
            redColoring = new Item() { Name = "Red Coloring", Description = "Red stuff" };
            blueColoring = new Item() { Name = "Blue Coloring", Description = "Blue stuff" };

            Recipe YellowDyeRecipe;
            Recipe RedDyeRecipe;
            Recipe BlueDyeRecipe;
            Recipe GreenDyeRecipe;

            YellowDyeRecipe = recipes.Recipes.Where(r => r.Name == "Yellow Dye Recipe").First();
            RedDyeRecipe = recipes.Recipes.Where(r => r.Name == "Red Dye Recipe").First();
            BlueDyeRecipe = recipes.Recipes.Where(r => r.Name == "Blue Dye Recipe").First();
            GreenDyeRecipe = recipes.Recipes.Where(r => r.Name == "Green Dye Recipe").First();

            IItem yellowDye;
            IItem redDye;
            IItem blueDye;
            IItem greenDye;

            yellowDye = YellowDyeRecipe.MakeRecipe(new List<IItem> { yellowColoring });
            redDye = RedDyeRecipe.MakeRecipe(new List<IItem> { redColoring });
            blueDye = BlueDyeRecipe.MakeRecipe(new List<IItem> { blueColoring });
            greenDye = GreenDyeRecipe.MakeRecipe(new List<IItem> { yellowColoring, blueColoring });
            items.Add(yellowDye);
            items.Add(redDye);
            items.Add(blueDye);
            items.Add(greenDye);
        }

        public string AboutItems()
        {
            string AboutItemsString = "Items\n---------------------------------------\n";
            foreach (var item in items)
            {
                AboutItemsString += item.About();
            }
            return AboutItemsString;
        }

        public string AboutRecipes()
        {
            string AboutRecipesString = "Recipes\n---------------------------------------\n";
            AboutRecipesString += recipes.About();
            return AboutRecipesString;
        }
    }
}
