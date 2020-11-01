using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;

namespace MiniVille
{

    class Player
    {
        public List<Card> cards;
        public string name;
        public int money;

        public Player(List<Card> cards, string name)
        {
            this.cards = cards;
            this.name = name;
            this.money = 3;
        }

        public void CheckCards(int dice, bool isPlaying, Player currentPlayer)
        {
            foreach (Card card in cards)
            {
                if (card.activation_value == dice)
                {
                    switch (card.color)
                    {
                        case "Blue":
                            Console.WriteLine("La carte Bleu \"{0}\" de {1} s'active.", card.name, name);
                            EarnMoney(card.earning_money);
                            break;

                        case "Green":
                            if (isPlaying)
                            {
                                Console.WriteLine("La carte Verte \"{0}\" de {1} s'active.", card.name, name);
                                EarnMoney(card.earning_money);
                            }
                            break;

                        case "Red":
                            if (!isPlaying)
                            {
                                Console.WriteLine("La carte Rouge \"{0}\" de {1} s'active.", card.name, name);
                                int gainedMoney = currentPlayer.LooseMoney(card.earning_money);
                                EarnMoney(gainedMoney);
                            }
                            break;
                    }
                }
            }
        }

        public int BuyCard()
        {
            return 1;
        }

        public void EarnMoney(int amount)
        {
            money += amount;

            Console.WriteLine("{0} a gagné {1} pièces et a maintenant {2} pièces !", name, amount, money);
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

            return oldMoney - money;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
