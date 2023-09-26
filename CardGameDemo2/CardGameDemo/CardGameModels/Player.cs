using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameDemo.CardGameModels
{
    public class Player
    {
        public string Name;
        List<Card> hand, take; 
        Game Game;

        static int playerCount;

        public Player(Game game)
        {
            Name = "Player " + playerCount++;
            hand = new List<Card>();
            take = new List<Card>();
            this.Game = game;
        }

        public void DrawCard()
        {
            hand.Add(this.Game.deck.DrawCard());
        }

        public void DrawCards(int howMany)
        {
            List<Card> drawnCards = this.Game.deck.DrawCards(howMany);
            foreach (Card card in drawnCards) { hand.Add(card); }
        }

        public void TakeCard(Card card)
        {
            this.take.Add(card);
        }

        public void TakeCard(Card[] cards)
        {
            foreach (Card tc in cards)
            {
                this.TakeCard(tc);
            }
        }

        public string About()
        {
            string playerAbout = $"Name : {Name}\n";
            playerAbout += "---------------------------------\n";
            playerAbout += "Hand\n";
            foreach (Card card in hand)
            {
                playerAbout += card.AboutCard() + "\n";
            }
            playerAbout += "---------------------------------\n";
            playerAbout += "Take\n";
            foreach (Card card in take)
            {
                playerAbout += card.AboutCard() + "\n";
            }
            return playerAbout;
        }

        internal Card PlayCard()
        {
            //what to do if there are no cards left
            if (hand.Count <= 0)
            {
                if (this.Game.deck.HasCards(5))
                {
                    this.DrawCards(5);
                }
                else
                {
                    this.Game.Stop();
                    throw new Exception("Game Over no more cards");
                }

            }
            Card c = hand[0];
            this.hand.RemoveAt(0);
            return c;

        }
    }
}
