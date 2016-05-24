using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Bowling_Exercise
{
    class Program
    {
        static void GameLoop (Scoreboard scoreboard, Random rand)
        {
            while (scoreboard.frameNumber < 10)
            {
                Console.Clear();

                // Calc throws
                int[] throws = new int[2];
                throws[0] = rand.Next(11);
                throws[1] = rand.Next(11 - throws[0]);

                Console.WriteLine("Frame: " + (scoreboard.frameNumber + 1));
                Console.WriteLine();

                scoreboard.RecordFrame(throws);

                // Scoreboard
                Console.WriteLine("\t| 1  |\t| 2  |\t| 3  |\t| 4  |\t| 5  |\t| 6  |\t| 7  |\t| 8  |\t| 9  |\t| 10 |");
                Console.WriteLine("        ------------------------------------------------------------------------------");
                for (int i = 0; i < 10; i++)
                    Console.Write("\t| " + scoreboard.frameTotals[i] + "  |");

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Throw #1: " + throws[0] + "\t" + "Throw #2: " + throws[1]);

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Total score: " + scoreboard.Score);

                Console.ReadLine();
            }

            //Console.ReadLine();
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Bowling Game!!!");
            Console.WriteLine("Press any key to start the game");

            Console.ReadLine();

            Scoreboard scoreboard = new Scoreboard();
            Random rand = new Random(DateTime.Now.Millisecond);

            GameLoop(scoreboard, rand);
        }
    }
}
