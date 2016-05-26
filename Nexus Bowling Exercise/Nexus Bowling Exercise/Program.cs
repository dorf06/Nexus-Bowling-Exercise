using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Bowling_Exercise
{
    class LeaderBoard
    {
        private int highScore { get; set; }
        private int averageScore { get; set; }

        private List<int> pastGames { get; set; }

        LeaderBoard ()
        {
            highScore = 0;
            averageScore = 0;
        }

        void AddGame (int score)
        {
            pastGames.Add(score);

            //averageScore = pastGames.Average();
        }
    }

    class Program
    {
        static void GameLoop ()
        {
            Scoreboard scoreboard = new Scoreboard();
            Random rand = new Random(DateTime.Now.Millisecond);

            while (scoreboard.frameNumber < 10)
            {
                // Calc throws
                int[] throws = new int[2];
                throws[0] = rand.Next(11);
                throws[1] = rand.Next(11 - throws[0]);

                //Tenth frame
                if (scoreboard.frameNumber == 9)
                {
                    int[] extraThrow = new int[3];

                    // Strike
                    if (throws[0] == 10)
                    {
                        extraThrow[0] = 10;
                        extraThrow[1] = rand.Next(11);

                        // Check for strike on second throw
                        if (extraThrow[1] == 10)
                            extraThrow[2] = rand.Next(11);
                        else
                            extraThrow[2] = rand.Next(11 - extraThrow[1]);
                    }
                    // Spare
                    else if (throws[0] + throws[1] == 10)
                    {
                        extraThrow[0] = throws[0];
                        extraThrow[1] = throws[1];
                        extraThrow[2] = rand.Next(11);
                    }
                    // Nada
                    else
                    {
                        extraThrow[0] = throws[0];
                        extraThrow[1] = throws[1];
                        extraThrow[2] = 0;
                    }

                    scoreboard.RecordFrame(extraThrow);
                }
                else
                    scoreboard.RecordFrame(throws);
            }

            Console.Clear();

            int totalScore = scoreboard.Score;

            Console.WriteLine();

            // Scoreboard
            Console.WriteLine("\t| 1  |\t| 2  |\t| 3  |\t| 4  |\t| 5  |\t| 6  |\t| 7  |\t| 8  |\t| 9  |\t| 10 |");
            Console.WriteLine("        ------------------------------------------------------------------------------");
            for (int i = 0; i < scoreboard.frameNumber; i++)
                Console.Write("\t|" + scoreboard.throwTracker[i][0] + "," + scoreboard.throwTracker[i][1] + "|");

            Console.WriteLine(scoreboard.throwTracker[9][2]);

            Console.WriteLine();

            for (int i = 0; i < scoreboard.frameNumber; i++)
                Console.Write("\t| " + scoreboard.frameTotals[i] + " |");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Total score: " + totalScore);
            
            Console.ReadLine();
        }

        static void Main(string[] args)
        {            
            Console.WriteLine("Welcome to the Bowling Game!!!");
            Console.WriteLine("Press any key to start the game");

            Console.ReadLine();
            
            while (true)
                GameLoop();
        }
    }
}
