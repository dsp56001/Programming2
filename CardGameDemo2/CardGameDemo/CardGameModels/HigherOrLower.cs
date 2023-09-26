using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameDemo.CardGameModels
{
    public class HigherOrLower : Game
    {
        
        
        public HigherOrLower() {
            this.Name = "Higher or Lower";
            setupGame();
        }

        protected override void setupGame()
        {
            base.setupGame();
            player.DrawCards(5);
            computerPlayer.DrawCards(5);
        }

        public override void PlayHand()
        {
            base.PlayHand();

            //Player 1 choose card
            try
            {
                Card playerCard = player.PlayCard();
                //Player 2 choose card
                Card computerCard = computerPlayer.PlayCard(); ;

                //compare card values
                Card winner = computerCard;
                if (playerCard.Value >= computerCard.Value)
                {
                    winner = playerCard;
                    if (playerCard.Value == computerCard.Value)
                    {
                        //check suits compare first letter
                        if (playerCard.Suit.ToCharArray()[0] >= computerCard.Suit.ToCharArray()[0])
                        {
                            winner = playerCard;
                        }
                        else
                        {
                            winner = computerCard;
                        }
                    }
                }

                //Give cards to winner
                //Check winner
                if (playerCard.Value == winner.Value && playerCard.Suit == winner.Suit)
                {
                    //player wins
                    player.TakeCard(new Card[] { playerCard, computerCard });
                }
                else
                {
                    //computer wins
                    computerPlayer.TakeCard(new Card[] { playerCard, computerCard });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

    }
}
