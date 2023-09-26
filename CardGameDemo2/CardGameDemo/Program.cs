using CardGameDemo.CardGameModels;
using CardGameDemo.UI;

namespace CardGameDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //FrenchSuited52CardDeck frenchDeck = new FrenchSuited52CardDeck();
            //Console.WriteLine(frenchDeck.AboutDeck());
            //frenchDeck.Shuffle();

            ApplicationUI app = new ApplicationUI();
            app.Start();
        }
    }
}