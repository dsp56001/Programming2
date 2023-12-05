﻿using ConsoleCaveSim.Models.Consumers;
using ConsoleCaveSim.Models.Producers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCaveSim.Models
{
    public class Cave : Enviroment
    {
        public Cave() 
        {
            this.Name = "Cave #" + this.Id;
            this.Description = "I like Caves!!!"; //just having fun TODO fix this
            this.SetupCave(5, 80);
        }

        private void SetupCave(int batCount, int cornCount)
        {
            for (int i = 0; i < batCount; i++)
            {
                this.Items.Add(new Bat(this));
            }

            for (int i = 0; i < cornCount; i++)
            {
                this.Items.Add(new Corn(this));
            }
        }

        public override string About()
        {
            string EnvAbout = string.Empty; //base.About();
            EnvAbout += "\nItems -------------";
            foreach (var entity in this.Items)
            {

                if (!(entity is Corn))
                {
                    EnvAbout += "\n" + entity.About();
                }
            }
            int corncount = this.Items.Where(i => i is Corn).Count();
            EnvAbout += "\nCorn Count " + corncount.ToString();
            return EnvAbout;
        }

        public override void Tick()
        {
            base.Tick();

            foreach(var item in Items)
            {
                item.Tick();
                if (item is Producer)
                {
                    //Producers gonna produce
                    if (item is Corn)
                    {
                        Corn c = (Corn)item;
                        if (c.State == CornState.Consumed || c.State == CornState.Expired)
                        {
                            itemsToRemove.Add(c);
                        } 
                    }
                }

            }

            //Add new items
            foreach (var item in itemsToAdd)
            {
                this.Items.Add(item);
            }
            itemsToAdd.Clear();
            //Remove remove items
            foreach (var item in itemsToRemove)
            {
                this.Items.Remove(item);
            }
            itemsToRemove.Clear();
        }
    }
}
