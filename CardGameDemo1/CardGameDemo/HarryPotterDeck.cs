using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameDemo
{
    public class HarryPotterDeck : Deck
    {
        public HarryPotterDeck() 
        {
            suits = new string[] { "Gryffindor", "Hufflepuff", "Ravenclaw", "Slytherin" };
            deckSize = 10;
            this.InitDeck();
        }
    }
}
