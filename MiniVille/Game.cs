using System;
using System.Collections.Generic;

namespace MiniVille
{

    class Game
    {
        public List<Player> players;
        public Pile pile;
        public List<Dice> dices;

        public Game()
        {
            List<Card> cards = new List<Card>();

            cards.Add(new Card("Champs de blé","blue",1,1,1));
            cards.Add(new Card("Ferme","Blue",2,1,1));
            cards.Add(new Card("Boulangerie","Green",1,2,2));
            cards.Add(new Card("Café","Red",2,1,3));
            cards.Add(new Card("Superette","Green",2,3,4));
            cards.Add(new Card("Forêt","Blue",2,1,5));
            cards.Add(new Card("Restaurant","Red",4,2,5)) ;
            cards.Add(new Card("Stade","Blue",6,4,6));
        }

        public void RunGame()
        {

        }

    }
}
