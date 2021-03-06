﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading;

namespace MiniVille
{

    class Game
    {
        public List<Player> players;
        public Pile pile;
        public List<Dice> dices;
        private Random rand;

        public Game()
        {
            rand = new Random();

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

            //Joueurs
            players = new List<Player>();
            this.players.Add(new Player(cards, "Joueur_1", "Player"));
            this.players.Add(new Player(cards, "Joueur_2", "IA"));

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

            while(!players.Any(p => p.money >= 20))
            {
                Console.WriteLine("Tour de {0}", this.players[current_player].name);
                Thread.Sleep(1000);
                //Lancer de dé
                this.LancerDes();
                Console.WriteLine(this.players[current_player].name + " a fait " + GetSumDices() + " avec son lancer de dé");
                Thread.Sleep(1000);

                //Recherche de carte Utilisable par les joueurs
                foreach (Player player in this.players)
                {
                    Console.WriteLine("\n{0} regarde ses cartes...", player.name);
                    Thread.Sleep(1000);
                    player.CheckCards(GetSumDices(), this.players[current_player]);
                }

                //Affichage et Achat des cartes achetables par le joueur
                if (this.players[current_player].type == "IA")
                {
                    if (this.players[current_player].money < 13)
                    {
                        List<Card> possibleCards = this.pile.Available_cards.FindAll(card => card.price <= this.players[current_player].money);
                        if (possibleCards.Count() > 0)
                        {
                            this.players[current_player].BuyCard(possibleCards[rand.Next(possibleCards.Count())]);
                        }
                    } else
                    {
                        Console.WriteLine("{0} n'a rien acheté.", this.players[current_player].name);
                    }
                }
                else
                {
                    this.pile.DisplayShop();
                    Console.WriteLine("Vous avez " + this.players[current_player].money + " pièce" + (this.players[current_player].money > 1 ? "s" : ""));
                    in_shop = true;
                    do
                    {
                        choix_achat = this.ChoixInteger("\nEntrez le numéro de la carte que vous souhaitez acheter", "numéro invalide", true, 0, true, this.pile.Available_cards.Count + 1);

                        if (choix_achat == this.pile.Available_cards.Count)
                        {
                            in_shop = false;
                        }
                        else
                        {
                            if (this.players[current_player].money >= this.pile.GetCard(choix_achat).price)
                            {
                                this.players[current_player].BuyCard(this.pile.GetCard(choix_achat));
                            }
                            else
                            {
                                Console.WriteLine("Vous n'avez pas asses d'argent");
                            }
                        }
                    } while (in_shop);
                }
                Thread.Sleep(1000);

                Console.WriteLine("\ntaper \"Entrer\" pour continuer.");
                Console.ReadLine();

                //Changement de joueur
                Console.Clear();
                current_player = (current_player + 1 == nb_players ? 0 : current_player + 1);
            }

            foreach (Player winner in players.FindAll(p => p.money >= 20))
            {
                Console.WriteLine("{0} a gagne avec {1} pièces", winner.name, winner.money);
            };
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
