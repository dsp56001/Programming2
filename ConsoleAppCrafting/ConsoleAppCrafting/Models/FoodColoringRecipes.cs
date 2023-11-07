using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleAppCrafting.Models
{
    internal class FoodColoringRecipes
    {
        //Private Instance Data Member
        List<Recipe> recipes;

        //Accessor
        public List<Recipe> Recipes
        {
            get { return recipes; }
        }

        public FoodColoringRecipes()
        {
            recipes = this.LoadRecipes();
        }


        public virtual List<Recipe> LoadRecipes()
        {
            //Ingredients
            IItem yellowColoring = new Item() { Name = "Yellow Coloring", Description = "Yellow stuff" };
            IItem redColoring = new Item() { Name = "Red Coloring", Description = "Red stuff" };
            IItem blueColoring = new Item() { Name = "Blue Coloring", Description = "Blue stuff" };

            IItem yellowDye = new Dye() { Name = "Yellow Dye", Description = "Turns things Yellow" };
            IItem redDye = new Dye() { Name = "Red Dye", Description = "Turns things Red" };
            IItem blueDye = new Dye() { Name = "Blue Dye", Description = "Turns things Blue" };
            IItem greenDye = new Dye() { Name = "Green Dye", Description = "Turns things Green" };
            IItem purpleDye = new Dye() { Name = "Purple Dye", Description = "Turns things purple" };

            //Recipes
            Recipe yellowDyeRecipe = new Recipe()
            {
                Description = "Yellow Dye is made from Yellow coloring",
                Name = "Yellow Dye Recipe",
                Ingredients = new List<IItem> {
                    yellowColoring
                },
                YieldAmount = 1,
                YieldItem = yellowDye
            };

            Recipe redDyeRecipe = new Recipe()
            {
                Description = "Red Dye is made from Red coloring",
                Name = "Red Dye Recipe",
                Ingredients = new List<IItem> {
                    redColoring
                },
                YieldAmount = 1,
                YieldItem = redDye
            };

            Recipe blueDyeRecipe = new Recipe()
            {
                Description = "Blue Dye is made from Blue coloring",
                Name = "Blue Dye Recipe",
                Ingredients = new List<IItem> {
                    blueColoring
                },
                YieldAmount = 1,
                YieldItem = blueDye
            };


            Recipe greenDyeRecipe = new Recipe()
            {
                Description = "Green Dye is made from Yellow and Blue coloring",
                Name = "Green Dye Recipe",
                Ingredients = new List<IItem> {
                    yellowColoring, blueColoring
                },
                YieldAmount = 2,
                YieldItem = greenDye
            };

            Recipe purpleDyeRecipe = new Recipe()
            {
                Description = "Purple Dye is make from Blue and Red Coloring",
                Name = "Purple Dye Recipe",
                Ingredients = new List<IItem> {
                    redColoring, blueColoring
                 },
                YieldAmount = 2,
                YieldItem = purpleDye
            };

            List<Recipe> recipes = new List<Recipe>()
            {
                 yellowDyeRecipe, blueDyeRecipe, redDyeRecipe, greenDyeRecipe, purpleDyeRecipe
            };

            return recipes;
        }

        internal string About()
        {
            string strAbout = string.Empty;
            foreach (Recipe recipe in recipes) 
            {
                strAbout += recipe.About();
            }
            return strAbout;
        }
    }
}
