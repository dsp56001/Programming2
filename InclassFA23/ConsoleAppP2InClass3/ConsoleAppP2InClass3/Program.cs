namespace ConsoleAppP2InClass3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            Dog d = new Dog();
            Console.WriteLine(d.About());


            Basenji cheddar = new Basenji();
            Console.WriteLine(cheddar.About());
            Console.WriteLine(cheddar.Bark());

            Cat rocket = new Cat();
            Console.WriteLine(rocket.About());

            Cat bella = new Cat { Name = "bella" };

            LitterBox downStairsLitterBox = new LitterBox();
            Console.WriteLine(downStairsLitterBox.About());
            bella.UseLitterBox(downStairsLitterBox);
            Console.WriteLine(downStairsLitterBox.About());

            Human jeff = new Human();

            Console.WriteLine(jeff.About());

            Human janell = new Human(bella);
        }
    }
}