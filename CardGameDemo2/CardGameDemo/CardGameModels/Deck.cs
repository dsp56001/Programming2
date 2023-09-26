using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameDemo.CardGameModels
{
    public class Deck
    {
        protected List<Card> cards;
        protected string[] suits;
        protected int deckSize;

        //private
        Random r;

        public Deck()
        {
            cards = new List<Card>();
            suits = new string[] { "Apples", "Oranges" };
            deckSize = 10;
            r = new Random();
            initDeck();
        }

        /// <summary>
        /// Initialize the deck with fresh cards
        /// </summary>
        public void initDeck()
        {
            cards.Clear(); //Clear the current deck
            for (int i = 0; i < deckSize; i++)
            {

                foreach (string s in suits)
                    AddCard(i, s);
            }
        }

        /// <summary>
        /// Add a card to the deck
        /// </summary>
        /// <param name="value">Value of the Card</param>
        /// <param name="suit">Suit of the Card</param>
        protected virtual void AddCard(int value, string suit)
        {
            cards.Add(new Card()
            {
                Value = value,
                Suit = suit,
            });
        }

        /// <summary>
        /// Lists all the cards in the Deck
        /// </summary>
        /// <returns>string of all the cards in the deck telling about themselves</returns>
        public string AboutDeck()
        {
            string about = "Deck\n----------------------------------------\n";
            foreach (Card card in cards)
            {
                about += card.AboutCard() + "\n";
            }
            return about.Trim();
        }

        /// <summary>
        /// Shuffles the deck
        /// </summary>
        public void Shuffle()
        {
            cards = GetShuffled();
        }

        /// <summary>
        /// Grandpa would get upset if the cards wern't mixed well might as well shuffle more than once
        /// </summary>
        /// <param name="howManyTimes">How many times to shuffle</param>
        public void Shuffle(int howManyTimes)
        {
            for (int i = 0; i < howManyTimes; i++)
            {
                cards = GetShuffled();
            }
        }

        /// <summary>
        /// Retruns a list of cards from the current deck that have been shuffled
        /// </summary>
        /// <returns>List of card that have been shuffled</returns>
        public List<Card> GetShuffled()
        {
            int selectedCardIndex;
            Card selectedCard;
            List<Card> original, shuffled;
            shuffled = new List<Card>();
            original = cards;
            while (original.Count > 0)
            {
                selectedCardIndex = r.Next(original.Count);
                selectedCard = original[selectedCardIndex];
                original.Remove(selectedCard);
                shuffled.Add(selectedCard);
            }
            return shuffled;
        }

        /// <summary>
        /// Take a card from the deck
        /// </summary>
        /// <returns>Returns the first item in the deck</returns>
        /// <exception cref="Exception"></exception>
        public Card DrawCard()
        {
            Card card;
            if (cards.Count <= 0)
            {
                throw new Exception("No cards left to draw");
            }
            card = cards[0];
            cards.Remove(card);
            return card;
        }

        /// <summary>
        /// Draw multiple cards from deck
        /// </summary>
        /// <param name="howMany">how many cards to draw</param>
        /// <returns>List of cards drawn from deck</returns>
        public List<Card> DrawCards(int howMany)
        {
            List<Card> drawnCards = cards.Take(howMany).ToList();
            foreach (Card drawCard in drawnCards)
            {
                cards.Remove(drawCard);
            }
            return drawnCards;
        }

        internal bool HasCards()
        {
            return this.cards.Count > 0;
        }

        internal bool HasCards(int howMany)
        {
            return this.cards.Count >= howMany;
        }
    }
}
