﻿using System;
using System.Collections.Generic;

namespace MiniVille
{

    class Pile
    {
        public List<Card> Available_cards { get; private set; }

        public Pile(List<Card> available_cards)
        {
            this.Available_cards = available_cards;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        //Returns the card with the wanted id
        public Card SellCard(int id)
        {
            Card card = Available_cards.Find(x => x.Id == id);
            return card;
        }

        //Show All cards with their information IN THE CONSOLE
        public void DisplayShop()
        {

        }
    }
}
