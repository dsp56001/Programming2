using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameDemo
{
    public class FrenchSuitedCard : Card
    {
        
        public enum FrechCardsNames { Ace = 0, One = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King}
        
        public FrenchSuitedCard()
        { 
            
        }

        public string GetCardName()
        {
            //Cast Card.Value to FrechCard Enum and return as a string
            return ((FrechCardsNames)this.Value).ToString();
        }

        public override string AboutCard()
        {
            return $"{this.GetCardName()} of {Suit}";
        }
    }
}
