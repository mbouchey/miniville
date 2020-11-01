using System;
using System.Collections.Generic;
using System.Linq;

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
        public Card GetCard(int id)
        {
            return Available_cards[id];
        }

        //Show All cards with their information IN THE CONSOLE
        public void DisplayShop()
        {
            for (int i = 0; i < Available_cards.Count(); i++)
            {
                Card card = Available_cards[i];
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
                WriteInColor(String.Format("\nID : {0}\n", i) + card.ToString(), color);
            }
            Console.WriteLine("\nTaper {0} pour ne rien acheter", Available_cards.Count());
                
        }

        public void WriteInColor(string message, ConsoleColor fore_color = ConsoleColor.White)
        {
            // Black / DarkBlue / DarkGreen / DarkCyan / DarkRed / DarkMagenta / DarkYellow / Gray / DarkGray / Blue / Green / Cyan / Red / Magenta / Yellow / White

            Console.ForegroundColor = fore_color;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}
