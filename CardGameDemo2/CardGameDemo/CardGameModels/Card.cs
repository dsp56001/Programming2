using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameDemo.CardGameModels
{
    public class Card
    {
        public int Value;
        public string Suit;

        public Card()
        {
            Value = 0;
            Suit = string.Empty;
        }

        public virtual string AboutCard()
        {
            return $"{Value} of {Suit}";
        }
    }
}
