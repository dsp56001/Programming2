using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameDemo
{
    public  class FruitDeck : Deck
    {

        public FruitDeck() 
        {
            suits = new string[] { "Apples", "Oranges", "Banana" };
            this.InitDeck();
        }
    }
}
