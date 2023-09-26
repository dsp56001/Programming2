using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameDemo.CardGameModels
{
    public class Game
    {
        public string Name;
        public Player player;
        public Player computerPlayer;
        public List<Player> players;
        public Deck deck;

        protected bool isPlaying;

        public Game()
        {
            this.Name = "Not a game";
            deck = new Deck();
            player = new Player(this);
            computerPlayer = new Player(this);
            players = new List<Player>()
            {
                player, computerPlayer
            };
            //setupGame();
        }

        protected virtual void setupGame()
        {
            deck.Shuffle();
            Console.Title = "Game : " + this.Name;
            
        }

        public virtual void Play()
        {
            isPlaying = true;
            do
            {
                this.PlayHand();
            } while (isPlaying);
        }
        public virtual void Stop()
        {
            isPlaying = false;
        }

        public virtual void PlayHand()
        {
            Console.WriteLine(deck.AboutDeck());
            Console.WriteLine(player.About());
            Console.WriteLine(computerPlayer.About());
            Console.ReadKey();
            Console.Clear();
        }
    }
}
