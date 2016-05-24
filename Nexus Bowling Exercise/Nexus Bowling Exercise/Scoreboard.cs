using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Bowling_Exercise
{
    class Scoreboard : ISimpleBowlingGame
    {
        // Scoring variables
        public int[] frameTotals = new int[10];

        // Tracking
        public int frameNumber;
        private int[][] throwTracker = new int[10][];

        // Throw counters
        int[] scoresStrike = new int[3];
        int[] scoresSpare = new int[2];
        int throwsStrike;
        int throwsSpare;

        // Special Tracking
        

        // Constructor
        public Scoreboard ()
        {
            // Set frames
            frameNumber = 0;
        }

        public void RecordFrame(params int[] throws)
        {
            throwTracker[frameNumber] = throws;
            
            frameNumber++;
        }

        public int Score
        {
            get
            {
                for (int i = 0; i < frameNumber; i++)
                {
                     // Check for strike
                     if (throwTracker[frameNumber][0] == 10)
                    {
                        int strikeScore = 0;

                        // Add next two throws to score
                    }

                    // Check for spare
                    if ((throwTracker[frameNumber][0] + throwTracker[frameNumber][1]) == 10)
                    {


                        // Add next throw
                    }

                    // Add pins
                    frameTotals[frameNumber] = throwTracker[frameNumber][0] + throwTracker[frameNumber][1];
                }

                return frameTotals.Sum();
            }
        }
    }
}
