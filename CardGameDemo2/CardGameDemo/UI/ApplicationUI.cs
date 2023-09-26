using CardGameDemo.CardGameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameDemo.UI
{
    public class ApplicationUI
    {

        ApplesOrOranges Game;
        
        public ApplicationUI() {
            this.Game = new ApplesOrOranges();
        }

        public void Start()
        {
           
            Game.Play();
        }

    }
}
