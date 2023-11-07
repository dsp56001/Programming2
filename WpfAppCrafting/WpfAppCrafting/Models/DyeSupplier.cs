using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCrafting.Models
{
    internal class DyeSupplier
    {
        List<Dye> dyes;
        List<Item> ingredients;
        List<Recipe> recipes;
        FoodColoringRecipes fcrecipes;
        public DyeSupplier() 
        {
            dyes = new List<Dye>()
            {
                new Dye() { Name = "Yellow Dye", Description = "Turns things Yellow" },
                new Dye() { Name = "Red Dye", Description = "Turns things Red" },
                new Dye() { Name = "Blue Dye", Description = "Turns things Blue" },
                new Dye() { Name = "Green Dye", Description = "Turns things Green" },
                new Dye() { Name = "Purple Dye", Description = "Turns things purple" }

            };
            ingredients = new List<Item>()
            {
                //Ingredients
                new Item() { Name = "Yellow Coloring", Description = "Yellow stuff" },
                new Item() { Name = "Red Coloring", Description = "Red stuff" },
                new Item() { Name = "Blue Coloring", Description = "Blue stuff" }
            };
            fcrecipes = new FoodColoringRecipes();
            recipes = fcrecipes.Recipes;
        }

        public List<IItem> GetDyeList()
        {
            return this.dyes.ToList<IItem>();
        }

        public IItem GetDye(string ItemName)
        {
            var dye = (IItem)this.dyes.Select(i => i.Name.Contains(ItemName));
            if(dye != null)
            {
                return dye;
            }
            throw new Exception($"Dye {ItemName} not found");
        }

        public List<IRecipe> GetRecipeList()
        {
            return this.recipes.ToList<IRecipe>();
        }

        public IRecipe GetRecipe(string RecipeName)
        {
            var recipe = this.recipes.Where(i => i.Name.Contains(RecipeName)).FirstOrDefault<IRecipe>();
            if(recipe != null)
            {
                return recipe;
            }
            throw new Exception($"Recipe {RecipeName} not found");
        }

        public List<IItem> GetIngredientList()
        {
            return this.ingredients.ToList<IItem>();
        }

        public IItem GetIngredient(string ItemName)
        {
            var item = this.ingredients.Where(i => i.Name == ItemName).FirstOrDefault<IItem>();
            if (item != null)
            {
                return item;
            }
            throw new Exception($"Ingretient {ItemName} not found");
        }

    }
}
