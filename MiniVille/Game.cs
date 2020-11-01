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
            Dictionary<string, Card> cards = new Dictionary<string, Card>();

            cards.Add("Champs de blé", new Card("Champs de blé","Blue",1,1,1));
            cards.Add("Ferme", new Card("Ferme","Blue",2,1,1));
            cards.Add("Boulangerie", new Card("Boulangerie","Green",1,2,2));
            cards.Add("Café", new Card("Café","Red",2,1,3));
            cards.Add("Superette", new Card("Superette","Green",2,3,4));
            cards.Add("Forêt", new Card("Forêt","Blue",2,1,5));
            cards.Add("Restaurant", new Card("Restaurant","Red",4,2,5));
            cards.Add("Stade", new Card("Stade","Blue",6,4,6));

            //Listes de cartes pour les joueurs au débuts de jeu
            List<Card> starterCards = new List<Card>
            {
                cards["Champs de blé"],
                cards["Boulangerie"]
            };

            //Joueurs
            players.Add(new Player(starterCards, "Joueur_1"));
            players.Add(new Player(starterCards, "Joueur_2"));

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
