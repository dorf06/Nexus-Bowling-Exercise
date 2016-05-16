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
        private int[] frameTotals = new int[10];

        // Tracking
        private int frameNumber;

        // Throw counters
        int[] scoresStrike = new int[3];
        int[] scoresSpare = new int[2];
        int throwsStrike;
        int throwsSpare;
        
        // Constructor
        public Scoreboard ()
        {
            // Set frames
            frameNumber = 0;
        }

        public void RecordFrame(params int[] throws)
        {
            // Check for strike
            if ( throws[0] == 10 )
            {
                // Strike

                // Check for 10th frame
                if ( (frameNumber + 1) == 10 )
                {

                }
            }
                
            else
            {
                // Check for spare
                if ( (throws[0] + throws[1]) == 10 )
                {
                    // Spare

                    // Check for 10th frame
                    if ( (frameNumber + 1) == 10 )
                    {

                    }
                }

                else
                {
                    frameTotals[frameNumber] = throws[0] + throws[1];
                }
            }
        }

        public int Score
        {
            get
            {
                return frameTotals.Sum();
            }
        }
    }
}
