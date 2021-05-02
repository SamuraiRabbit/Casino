using System;

namespace Casino
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            double odds = .75;
            Guy.Guy player = new Guy.Guy { cash = 100, name = "The Player" };

            Console.WriteLine("Welcom to the Casino. The odds are " + odds);
            while (player.cash > 0)
            {
                player.WriteMyInfo();

                Console.WriteLine("How much would you like to bet?");
                string howMuch = Console.ReadLine();
                if (int.TryParse(howMuch, out int amount))
                {
                    int pot = player.GiveCash(amount) * 2;
                    if (pot > 0)
                    {
                        if (random.NextDouble() > odds)
                        {
                            int winnings = pot;
                            Console.WriteLine("You win " + winnings + " bucks!");
                            player.ReceiveCash(winnings);
                        }
                        else
                        {
                            Console.WriteLine("Bad luck, you lose.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                }
            }
            Console.WriteLine("The house always wins.");

        }
    }
}
