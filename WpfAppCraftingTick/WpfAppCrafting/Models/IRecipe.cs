using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCrafting.Models
{
    
        public interface IRecipe 
        {
            List<IItem> Ingredients { get; }
            float YieldAmount { get; }
            IItem YieldItem { get; }
            IItem MakeRecipe(List<IItem> sourceItems); 
        }
    
}
