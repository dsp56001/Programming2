using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameDemo.CardGameModels
{
    internal class ApplesOrOranges : Game
    {
        public ApplesOrOranges() 
        {
            this.Name = "Apples or Oranges";
            this.setupGame();
        }
    }
}
