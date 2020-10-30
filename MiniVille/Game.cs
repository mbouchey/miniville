using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace MiniVille
{

    class Game
    {
        public List<Player> players;
        public Pile pile;
        public List<Dice> dices;

        public Game()
        {
            //Cartes
            List<Card> cards = new List<Card>();

            cards.Add(new Card("Champs de blé","blue",1,1,1));
            cards.Add(new Card("Ferme","Blue",2,1,1));
            cards.Add(new Card("Boulangerie","Green",1,2,2));
            cards.Add(new Card("Café","Red",2,1,3));
            cards.Add(new Card("Superette","Green",2,3,4));
            cards.Add(new Card("Forêt","Blue",2,1,5));
            cards.Add(new Card("Restaurant","Red",4,2,5));
            cards.Add(new Card("Stade","Blue",6,4,6));

            //Joueurs
            players.Add(new Player());
            players.Add(new Player());

            //Dés
            dices.Add(new Dice());

            Console.WriteLine("Voulez-vous jouer avec deux dés ? (oui - non)");
            if (Console.ReadLine() == "oui")
            {
                dices.Add(new Dice());
            }
        }

        public void RunGame()
        {
            while(/*variable money*/)
            {
                //Lancer de dé du joueur A
                
                //Recherche de carte Utilisable par le joueur B (carte Rouge ou Bleu)

                //Recherche de carte Utilisable par le joueur A (carte Verte ou Bleu)

                //Affichage et Achat des cartes achetables par le joueur A

                //Fin du tour Joueur A

                //Lancer de dé du joueur B

                //Recherche de carte Utilisable par le joueur A (carte Rouge ou Bleu)

                //Recherche de carte Utilisable par le joueur B (carte Verte ou Bleu)

                //Affichage et Achat des cartes achetables par le joueur B

                //Fin du tour Joueur B

            }
        }

    }
}
