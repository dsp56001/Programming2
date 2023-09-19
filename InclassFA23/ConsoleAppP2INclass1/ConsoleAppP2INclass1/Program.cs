using System;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace ConsoleAppP2INclass1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PeopleStuff();
            //ChairStuff();

            Chair spinnyChair = new Chair();

            while(true)
            {
                InteractiveChair(spinnyChair);
            }
            
        }

        private static void InteractiveChair(Chair c)
        {
            Console.WriteLine(c.About());
            Console.Write("write u to go up or d to go down : ");
            
            ConsoleKeyInfo key  = Console.ReadKey();
            switch(key.KeyChar)
            {

                case 'u':
               
                    c.GoUp();
                    break;
                case 'd':
                
                       c.GoDown();
                    break;
                default:
                    Console.WriteLine("sorry i dont understand");
                    break;
            }
            
        }

        private static void ChairStuff()
        {
            Chair blackChair; //Declaration
            blackChair = new Chair(); //Initialization

            Chair woodenChair = new Chair();
            woodenChair.Material = "Wood";

            Chair greenChair = new Chair() { Color = "Green", Material = "Vinyl" };

            Chair spinnyChair = new Chair() 
            { 
                Color = "Gray", 
                Material = "Plastic", 
                Height = 10 
            };
            spinnyChair.GoUp();
            spinnyChair.GoUp(2);
            spinnyChair.GoUp(2, 2);

            Stool blackStool = new Stool();

            //Array of chairs
            List<Item> items = new List<Item>();
            items.Add(blackChair);
            items.Add(woodenChair);
            items.Add(greenChair);
            items.Add(spinnyChair);
            items.Add(blackStool);
            items.Add(new WarHammer());
            items.Add(new Cat());
            

            foreach (var i in items)
            {
                Console.WriteLine(i.About());
            }

        }

        private static void PeopleStuff()
        {
            //Create a person
            Person jeff = new Person();
            jeff.FirstName = "Jeff";
            jeff.LastName = "Meyers";
            jeff.Currency = int.MaxValue;
            jeff.cat = new Cat();

            //Make another person
            Person student = new Person()
            {
                FirstName = "X",
                LastName = "G",
                Currency = 7,
                cat = new Cat() { Name = "fluffy" }
            };
            Person person = new Person();
            bool sayHello = true;
            if (sayHello)
            {
                //1ist person say hello
                Console.WriteLine(jeff.SayHello());
                Console.WriteLine(jeff.cat.Name);
                Console.WriteLine(student.SayHello());
            }
            Console.WriteLine(jeff.SayGoodbye());
        }
    }
}