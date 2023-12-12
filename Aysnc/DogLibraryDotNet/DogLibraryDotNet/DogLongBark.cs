using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DogLibrary;

namespace DogLibraryDotNet
{
    public class DogLongBark : Dog
    {



        public override string Bark()
        {
            Console.WriteLine("Sleep for 5 seconds.");
            Thread.Sleep(5000);

            return base.Bark();
        }

       
    }
}

