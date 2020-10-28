using System;
using System.Collections.Generic;

namespace MiniVille
{

    class Pile
    {
        public List<CardsInfo> Available_cards { get; private set; }

        public Pile(List<CardsInfo> available_cards)
        {
            this.Available_cards = available_cards;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public Card SellCard()
        {
            
        }

        //Show All cards with their information IN THE CONSOLE
        public void DisplayShop()
        {

        }
    }
}
