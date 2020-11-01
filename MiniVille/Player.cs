using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MiniVille
{

    class Player
    {
        public List<Card> cards;
        public string name;
        public string type;
        public int money;

        public Player(List<Card> cards, string name, string type = "IA")
        {
            //Listes de cartes pour les joueurs au débuts de jeu
            List<Card> starterCards = new List<Card>
            {
                cards[0],
                cards[2]
            };
            this.cards = starterCards;
            this.name = name;
            this.type = type;
            this.money = 3;
        }

        public void CheckCards(int dice, Player currentPlayer)
        {
            DisplayCards();
            Thread.Sleep(1000);
            bool isPlaying = this.Equals(currentPlayer);
            foreach (Card card in cards)
            {
                if (card.activation_value == dice)
                {
                    switch (card.color)
                    {
                        case "Blue":
                            Console.WriteLine("La carte Bleu \"{0}\" de {1} s'active.", card.name, name);
                            Thread.Sleep(1000);
                            EarnMoney(card.earning_money);
                            break;

                        case "Green":
                            if (isPlaying)
                            {
                                Console.WriteLine("La carte Verte \"{0}\" de {1} s'active.", card.name, name);
                                Thread.Sleep(1000);
                                EarnMoney(card.earning_money);
                            }
                            break;

                        case "Red":
                            if (!isPlaying)
                            {
                                Console.WriteLine("La carte Rouge \"{0}\" de {1} s'active.", card.name, name);
                                Thread.Sleep(1000);
                                int gainedMoney = currentPlayer.LooseMoney(card.earning_money);
                                EarnMoney(gainedMoney);
                            }
                            break;
                    }
                }
            }
        }

        public void BuyCard(Card newCard)
        {
            cards.Add(newCard);
            LooseMoney(newCard.price);
            Console.WriteLine("{0} a acheté la carte \"{1}\" !", name, newCard.name);
            Thread.Sleep(1000);
        }

        public void EarnMoney(int amount)
        {
            money += amount;

            Console.WriteLine("{0} a gagné {1} pièces et a maintenant {2} pièces !", name, amount, money);
            Thread.Sleep(1000);
        }

        public int LooseMoney(int amount)
        {
            int oldMoney = money;
            if (money == 0)
            {
                Console.WriteLine("{0} a déjà perdu tout ses pièces.", name);
            }
            else if (money - amount <= 0)
            {
                money = 0;
                Console.WriteLine("{0} a perdu tout ses pièces.", name);
            }
            else
            {
                money -= amount;
                Console.WriteLine("{0} a perdu {1} pièces et a maintenant {2} pièces.", name, amount, money);
            }
            Thread.Sleep(1000);

            return oldMoney - money;
        }

        public override string ToString()
        {
            return name;
        }

        public void DisplayCards()
        {
            for (int i = 0; i < cards.Count(); i++)
            {
                Card card = cards[i];
                ConsoleColor color;
                switch (card.color)
                {
                    case "Red":
                        color = ConsoleColor.Red;
                        break;

                    case "Blue":
                        color = ConsoleColor.Blue;
                        break;

                    case "Green":
                        color = ConsoleColor.Green;
                        break;

                    default:
                        color = ConsoleColor.White;
                        break;
                }
                WriteInColor("\n" + card.name, color);
            }
            Console.WriteLine();
        }

        public void WriteInColor(string message, ConsoleColor fore_color = ConsoleColor.White)
        {
            // Black / DarkBlue / DarkGreen / DarkCyan / DarkRed / DarkMagenta / DarkYellow / Gray / DarkGray / Blue / Green / Cyan / Red / Magenta / Yellow / White

            Console.ForegroundColor = fore_color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
