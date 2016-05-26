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
        public int[] frameTotals;

        // Tracking
        public int frameNumber;
        public int[][] throwTracker;

        // Constructor
        public Scoreboard ()
        {
            // Set frames
            frameNumber = 0;

            frameTotals = new int[10];
            throwTracker = new int[10][];
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
                for (int tempFrame = 0; tempFrame < frameNumber; tempFrame++)
                {
                    if (tempFrame < 9)
                    {
                        // Check for strike
                        if (throwTracker[tempFrame][0] == 10)
                        {
                            // Add next two throws to score
                            // Check if next throw is a strike
                            if (throwTracker[tempFrame + 1][0] != 10)
                                // Not a strike, so add next throws like normal
                                frameTotals[tempFrame] = 10 + throwTracker[tempFrame + 1][0] + throwTracker[tempFrame + 1][1];
                            else
                            {
                                // Turns out I was wrong, different logic for 9th frame strike
                                if (tempFrame != 8)
                                    // Next throw is strike, add 10, then add frame after first throw (Doesnt matter what it is)
                                    frameTotals[tempFrame] = 10 + 10 + throwTracker[tempFrame + 2][0];
                                else
                                    // 9th frame strike, 10th frame strike, then take second throw of 10th
                                    frameTotals[tempFrame] = 10 + 10 + throwTracker[9][1];
                            }
                        }

                        // Check for spare
                        else if ((throwTracker[tempFrame][0] + throwTracker[tempFrame][1]) == 10)
                        {
                            // Add next throw
                            frameTotals[tempFrame] = 10 + throwTracker[tempFrame + 1][0];
                        }

                        else
                            // Add pins
                            frameTotals[tempFrame] = throwTracker[tempFrame][0] + throwTracker[tempFrame][1];
                    }
                    // 10th frame
                    else
                    {
                        // Check for strike
                        if (throwTracker[tempFrame][0] == 10)
                        {
                            frameTotals[9] = 10 + throwTracker[9][1] + throwTracker[9][2];
                        }

                        // Check for spare
                        else if ((throwTracker[tempFrame][0] + throwTracker[tempFrame][1]) == 10)
                        {
                            // Add next throw
                            frameTotals[tempFrame] = 10 + throwTracker[9][2];
                        }

                        else
                            // Add pins
                            frameTotals[tempFrame] = throwTracker[tempFrame][0] + throwTracker[tempFrame][1];
                    }
                }

                // Add the frames and the extra throw
                return frameTotals.Sum();
            }
        }
    }
}
