namespace CardGameDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck firstDeck = new Deck();
            Console.WriteLine(firstDeck.AboutDeck());

            HarryPotterDeck harrytDeck = new HarryPotterDeck();
            Console.WriteLine(harrytDeck.AboutDeck());

            FruitDeck fruitDeck = new FruitDeck();
            Console.WriteLine(fruitDeck.AboutDeck());
        }
    }
}