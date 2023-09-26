using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameDemo.CardGameModels
{
    public class FrenchSuited52CardDeck : Deck
    {
        public FrenchSuited52CardDeck()
        {
            deckSize = 13;
            suits = new string[] { "Diamonds", "Hearts", "Clubs", "Spades" };

            initDeck();
        }

        protected override void AddCard(int value, string suit)
        {
            cards.Add(new FrenchSuitedCard()
            {
                Value = value,
                Suit = suit,
            });
        }
    }
}
