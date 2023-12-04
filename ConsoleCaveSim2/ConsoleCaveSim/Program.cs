using ConsoleCaveSim.Models;
using ConsoleCaveSim.Models.Consumers;
using ConsoleCaveSim.Models.Producers;

namespace ConsoleCaveSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Caninator 9000");

            //Do some entity testing

            Cave sim = new Cave();

            sim.Add(new Bat(sim));
            sim.Add(new Bat(sim));
            sim.Add(new Bat(sim));
            sim.Add(new Corn());
            sim.Add(new Corn());
            sim.Add(new Corn());



            ConsoleKey key = ConsoleKey.Enter;
            do
            {
                Console.Clear();
                Console.WriteLine(sim.About());
                sim.Tick();
                key = Console.ReadKey().Key;
            } while (key != ConsoleKey.Q);



        }
    }
}