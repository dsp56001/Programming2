using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameDemo
{
    public class Deck
    {
        List<Card> cards;
        protected string[] suits;
        protected int deckSize;

        public Deck()
        {
            cards = new List<Card>();
            suits = new string[] { "Apples", "Oranges" };
            deckSize = 10;
        }

        public void InitDeck()
        {
            for (int i = 0; i < deckSize; i++) { 
            
                foreach (string s in suits)
                {
                    cards.Add(new Card()
                    {
                        Value = i,
                        Suit = s,
                    });
                }
            }
        }

        public string AboutDeck()
        {
            string about = string.Empty;
            foreach(Card card in cards)
            {
                about += card.AboutCard() + "\n";
            }
            return about.Trim();
        }
    }
}
