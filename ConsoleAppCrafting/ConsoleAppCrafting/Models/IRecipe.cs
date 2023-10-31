using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCrafting.Models
{
    
        public interface IRecipe : IItem
        {
            List<IItem> Ingredients { get; }
            float YieldAmount { get; }
            string YieldName { get; }
        }
    
}
