using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleAppCrafting.Models
{
    internal class FoodColoringRecipiedFromXML : FoodColoringRecipes
    {
        public override List<Recipe> LoadRecipes()
        {
            List<Recipe> recipes = new List<Recipe>();  //List to return at the end

            //Path to XML file notice the . starts the relative path file is in the Data folder
            string fileName = ".\\Data\\DyeRecipes.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode ?root = doc.DocumentElement; //start at the root of the document
            if (root == null) { throw new Exception($"{fileName} not xml"); }
            XmlNodeList ?recipeNodes = root.SelectNodes("/Recipes/Recipe"); //Select the Recipes node
            if(recipeNodes == null ) { throw new Exception("Recipes not found in XMl"); }
            foreach (XmlElement r in recipeNodes)
            {
                //Amount is an int parse it out
                int yieldAmount = 0;
                if (int.TryParse(r.GetAttribute("YieldAmount"), out int y))
                { yieldAmount = y; }

                //Get the YieldItem from the YieldItem Node
                Item yieldItem = new Item();
                //Get the Yield Item
                XmlNode ?YieldNode = r.SelectSingleNode("YieldItem/IItem");
                if(YieldNode == null) { throw new Exception("No IItems in YieldItem"); }
                if (YieldNode.Attributes == null) { throw new Exception("No IItems in YieldItem"); }
                if (YieldNode.Attributes["Name"] == null) { throw new Exception("No YieldItem Name"); }
                if (YieldNode.Attributes["Name"] != null && YieldNode.Attributes["Description"] != null)
                {
                    var nameAttibute = YieldNode.Attributes["Name"];
                    var descAttribute = YieldNode.Attributes["Description"];
                    if (nameAttibute == null) { throw new Exception("No IItem Name"); }
                    yieldItem.Name = nameAttibute.Value;
                    if (descAttribute == null) { throw new Exception("No IItem Description"); }
                    yieldItem.Description = descAttribute.Value;
                }

                //Get ingredients form the Ingredients Node
                List<IItem> ingredients = new List<IItem>();
                XmlNodeList ?childIngredientItemsNodes = r.SelectNodes("Ingredients/IItem");
                if(childIngredientItemsNodes == null ) { throw new Exception("No IItems in ingredients"); }
                foreach (XmlElement child in childIngredientItemsNodes)
                {
                    ingredients.Add(new Item()
                    {
                        Name = child.GetAttribute("Name"),
                        Description = child.GetAttribute("Description"),
                    });
                }
                

                //add the instance to the list that will be returned from method
                recipes.Add(new Recipe
                {
                    //object initialization with public class fields
                    Name = r.GetAttribute("Name"),
                    Description = r.GetAttribute("Description"),
                    YieldAmount = yieldAmount,
                    Ingredients = ingredients,
                    YieldItem = yieldItem
                });
            }
            return recipes;
        }
    }
}
