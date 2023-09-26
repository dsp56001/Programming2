using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppP2INclass1
{
    public class Chair : Item
    {
        public string Material;
        public string Color;
        public int NumLegs;
        public int Height;
        public bool hasBack;

        //Contructor
        //Same name as the class and no return type
        public Chair()
        {
            this.Name = "Chair";
            this.Description = "some chair";
            
            this.Color = "black";
            this.NumLegs = 4;
            this.Material = "default material";
            this.Height = 5;
            this.hasBack = true;

        }

        public void GoUp()
        {
            //change the hieight
            this.Height = this.Height + 1;

        }

        public void GoUp(int HowMuch)
        {
            this.Height += HowMuch;
        }

        public void GoUp(int HowMuch, int HowManyTimes)
        {
            this.Height += HowMuch * HowManyTimes;
        }

        public void GoDown()
        {
            this.Height--;
            if(this.Height < 0)
                this.Height = 0;
        }

        public void GoDown(int HowMuch)
        {
            for (int i = 0; i < HowMuch; i++)
            {
                this.GoDown();
            }
        }

        public override string About()
        {
            return base.About() + $" material : {this.Material} \t color : {this.Color} \t legs : {this.NumLegs} \t height : {this.Height} : hasBack {this.hasBack}";
        }

        
             
        
    }
}