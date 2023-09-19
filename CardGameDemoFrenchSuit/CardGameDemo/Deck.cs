using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameDemo
{
    public class Deck
    {
        protected List<Card> cards;
        protected string[] suits;
        protected int deckSize;

        public Deck()
        {
            cards = new List<Card>();
            suits = new string[] { "Apples", "Oranges" };
            deckSize = 10;
        }

        public void initDeck()
        {
            for (int i = 0; i < deckSize; i++) {

                foreach (string s in suits)
                    AddCard(i, s);
            }
        }

        protected virtual void AddCard(int value, string suit)
        {
            cards.Add(new Card()
            {
                Value = value,
                Suit = suit,
            });
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
