namespace CardGameDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck firstDeck = new Deck();
            firstDeck.initDeck();
            Console.WriteLine(firstDeck.AboutDeck());

            FrenchSuited52CardDeck frenchDeck = new FrenchSuited52CardDeck();
            Console.WriteLine(frenchDeck.AboutDeck());
        }
    }
}