namespace ConsoleAppCrafting.Models
{
    

    public class Item : IItem
    {
        public string Name { get; set; }

        public string Description { get; set; } 

        public Item()
        {
            this.Name = "Ingredient Name";
            this.Description = "Ingredient Descrition";
        }

        public string About()
        {
            return $"Name:\t\t{this.Name}\nDescrtiption:\t{this.Description}\n";
        }
    }
}