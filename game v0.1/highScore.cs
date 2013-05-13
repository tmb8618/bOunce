// Entire class created by Daniel Pascucci
// Run in release mode NOT debug mode, otherwise it will select a different default directory
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace game_v0._1
{
    class highScore
    {
        public bool highScoreChanged = false;
        public string highestScorePlayerName;
        public int highestPlayerScore = 0;
        public List<int> playerScores = new List<int>();
        public List<int> highScoreList = new List<int>();
        public List<player> players = new List<player>();
        public List<string> playerScoreRankings = new List<string>();

        public highScore(List<player> playerList)
        {
            players = playerList;
        }

        /// <summary>
        /// Reads in the high score list from a file
        /// </summary>
        /// <param name="fileName">filename of high score list txt file</param>
        public void readScoreList(string fileName)
        {
            highScoreList.Clear();
            StreamReader highScoreReader = new StreamReader(fileName);
            while (!highScoreReader.EndOfStream)
            {
                // Sometimes an empty file still has line breaks or a space or two, this "if statement"
                // makes sure the high score list isn't this type of psuedo-empty
                if (int.TryParse("" + ((char)highScoreReader.Peek()), out highestPlayerScore))
                {
                    // Adds a new entry to the current high score list
                    highScoreList.Add(int.Parse((string)highScoreReader.ReadLine()));
                }
                else
                {
                    // If the file is psuedo-empty (has line breaks or spaces but no actual content)
                    // this statement jumps to the end of the stream to end the loop
                    highScoreReader.ReadToEnd();
                }
            }
            highScoreReader.Close();
            if (highScoreList.Count > 1)
            {
                if (highScoreList[highScoreList.Count - 1] == 0)
                {
                    highScoreList.RemoveAt(highScoreList.Count - 1);
                }
            
            }

        }

        /// <summary>
        /// Writes the current high score list to the text file
        /// </summary>
        /// <param name="fileName">filename of high score list txt file</param>
        public void writeScoreList(string fileName)
        {
            StreamWriter highScoreWriter = new StreamWriter(fileName);
            foreach (int highScore in highScoreList)
            {
                highScoreWriter.WriteLine("" + highScore);
            }
            highScoreWriter.Close();
        }
        
        /// <summary>
        /// Computes the new high score list
        /// </summary>
        public void computeNewScoreList()
        {
            // Makes sure this isn't called multiple times in one game
            if (!highScoreChanged)
            {
                foreach (player player in players)
                {
                    // Computes the winner of the game
                    if (player.score > highestPlayerScore)
                    {
                        highestPlayerScore = player.score;
                        highestScorePlayerName = player.name;
                    }
                    playerScores.Add(player.score);
                }
                // Runs through each player and finds his position on the high score list
                for(int x = 0; x < playerScores.Count; x++)
                    {
                        bool newEntry = false;
                        if (highScoreList.Count == 0)
                        {
                            highScoreList.Add(playerScores[x]);
                            playerScoreRankings.Add((string)(players[x].name + " is the first ever entry in the highscore list "));
                        }
                        // Runs through each entry on the high score list
                        for (int i = 0; i < highScoreList.Count; i++)
                        {
                            // Checks the players score against each entry to see if it should be placed there
                            if (playerScores[x] > highScoreList[i] && !newEntry)
                            {
                                // These if statements make sure the correct statement is applied to the characters high score position
                                highScoreList.Insert(i, playerScores[x]);
                                if (highScoreList.Count > 1000)
                                {
                                    highScoreList.RemoveAt(highScoreList.Count - 1);
                                    playerScoreRankings.Add((string)(players[x].name + " made the high score list at position " + (i + 1)));
                                }
                                else if (i == highScoreList.Count - 1)
                                {
                                    playerScoreRankings.Add((string)(players[x].name + " has the worst score of all time and was appended to the end of the high score list at position " + highScoreList.Count));
                                }
                                else
                                {
                                    playerScoreRankings.Add((string)(players[x].name + " made the high score list at position " + (i + 1)));
                                }
                                newEntry = true;
                            }
                            // Checks to see if the player didn't make it on the score list at all
                            if (i == highScoreList.Count - 1 && !newEntry)
                            {
                                playerScoreRankings.Add((string)(players[x].name + " Did not make it into the top 1000 scores "));
                            }
                        }
                    }
                    highScoreChanged = true;
                }
            }
        }
    }

