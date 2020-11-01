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
            int current_player = 0;
            int nb_players = this.players.Count;

            while(/*variable money*/)
            {
                //Lancer de dé
                this.LancerDes();

                //Recherche de carte Utilisable par le joueur (carte Verte ou Bleu)
                foreach (var card in this.players[current_player].cards)
                {
                    if ((card.color == "Green" || card.color == "Blue") && this.GetSumDices() >= card.activation_value)
                    {
                        this.players[current_player].EarnMoney(card.earning_money);
                    }
                }

                //Recherche de carte Utilisable par les autres joueurs (carte Rouge ou Bleu)
                for (int i = 0; i < nb_players; i++)
                {
                    if (i != current_player)
                    {
                        foreach (var card in this.players[i].cards)
                        {
                            if ((card.color == "Red" || card.color == "Blue") && this.GetSumDices() >= card.activation_value)
                            {
                                this.players[i].EarnMoney(card.earning_money);
                            }
                        }
                    }
                }

                //Affichage et Achat des cartes achetables par le joueur

                //Changement de joueur
                current_player = (current_player + 1 == nb_players ? 0 : current_player + 1);
            }
        }

        private void LancerDes()
        {
            foreach (var dice in dices)
            {
                dice.Lancer();
            }
        }

        private int GetSumDices()
        {
            int sum = 0;
            foreach (var dice in dices)
            {
                sum += dice.face;
            }

            return sum;
        }
    }
}
