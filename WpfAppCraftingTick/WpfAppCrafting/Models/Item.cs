namespace ConsoleAppCrafting.Models
{
    

    public class Item : IItem
    {
        public string Name { get; set; }

        public string Description { get; set; } 

        public decimal Price { get; set; }

        public Item()
        {
            this.Name = "Item Name";
            this.Description = "Item Description";
            this.Price = 0;
        }

        public string About()
        {
            return $"Name:\t\t{this.Name}\tDescrtiption:\t{this.Description}\t{this.Price:c}\n";
        }

        public override bool Equals(object? obj)
        {
            if(obj is IItem) 
            { 
                return this.Name.Equals(((IItem)obj).Name);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}