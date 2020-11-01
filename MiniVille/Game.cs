using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

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

            cards.Add(new Card("Champs de blé","Blue",1,1,1));
            cards.Add(new Card("Ferme","Blue",2,1,1));
            cards.Add(new Card("Boulangerie","Green",1,2,2));
            cards.Add(new Card("Café","Red",2,1,3));
            cards.Add(new Card("Superette","Green",2,3,4));
            cards.Add(new Card("Forêt","Blue",2,1,5));
            cards.Add(new Card("Restaurant","Red",4,2,5));
            cards.Add(new Card("Stade","Blue",6,4,6));

            pile = new Pile(cards);

            //Listes de cartes pour les joueurs au débuts de jeu
            List<Card> starterCards = new List<Card>
            {
                cards[0],
                cards[2]
            };

            //Joueurs
            players = new List<Player>();
            this.players.Add(new Player(starterCards, "Joueur_1", "Player"));
            this.players.Add(new Player(starterCards, "Joueur_2", "IA"));

            //Dés
            dices = new List<Dice>();
            dices.Add(new Dice());

            Console.WriteLine("Voulez-vous jouer avec deux dés ? (oui - non)");
            if (Console.ReadLine() == "oui")
            {
                dices.Add(new Dice());
            }

            RunGame();
        }

        public void RunGame()
        {
            int current_player = 0;
            int nb_players = this.players.Count;
            int choix_achat;
            bool in_shop;

            while(players.Any(p => p.money < 20))
            {
                Console.WriteLine(players.Any(p => p.money >= 20));
                //Lancer de dé
                this.LancerDes();
                Console.WriteLine(this.players[current_player].name + " a fait " + GetSumDices() + " avec son lancer de dé");

                //Recherche de carte Utilisable par les joueurs
                foreach (Player player in this.players)
                {
                    player.CheckCards(GetSumDices(), this.players[current_player]);
                }

                //Affichage et Achat des cartes achetables par le joueur
                if (this.players[current_player].type == "IA")
                {
                    

                }
                else
                {
                    Console.WriteLine("Vous avez " + this.players[current_player].money + " pièce" + (this.players[current_player].money > 1 ? "s" : ""));
                    this.pile.DisplayShop();
                    in_shop = true;
                    do
                    {
                        choix_achat = this.ChoixInteger("Entrez le numéro de la carte que vous souhaitez acheter", "numéro invalide", true, 0, true, this.pile.Available_cards.Count + 1);

                        if (this.players[current_player].money >= this.pile.GetCard(choix_achat).price)
                        {
                            this.players[current_player].BuyCard(this.pile.GetCard(choix_achat));
                        }

                        if (choix_achat == this.pile.Available_cards.Count)
                        {
                            in_shop = false;
                        }
                    } while (in_shop);
                }

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

        //Fonction qui restreint le choix d'un integer par l'utilisateur et qui permet la définition d'une range de sélection
        public int ChoixInteger(string message, string error = "", bool haveFrom = false, int from = 0, bool haveTo = false, int to = 0)
        {
            int integer;
            bool nb_valide;

            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }
            do
            {
                Console.Write("> ");
                nb_valide = int.TryParse(Console.ReadLine(), out integer);
                if ((integer < from && haveFrom) || (integer >= to && haveTo))
                {
                    nb_valide = false;
                }
                if (!nb_valide && !String.IsNullOrWhiteSpace(error))
                {
                    Console.WriteLine(error);
                }
            } while (!nb_valide);

            return integer;
        }
    }
}
