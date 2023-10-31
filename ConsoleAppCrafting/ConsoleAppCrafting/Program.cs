
using ConsoleAppCrafting.Models;
using ConsoleAppCrafting.UI;
using System.Runtime.InteropServices;

namespace ConsoleAppCrafting
{
    internal class Program
    {
        static void Main(string[] args)
        {

            UIApplcationTester tester = new UIApplcationTester();
            Console.WriteLine(tester.AboutItems());
            Console.WriteLine(tester.AboutRecipes()); ;
        }
    }
}