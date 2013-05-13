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
    class sceneControl
    {
        public scene scene;
        public int playerCount;
        public int keyboardPlayer;
        public int difficulty;
        public string[] playerNames;
        public int mirrorCount;
        public textureBox textures;

        public Rectangle viewPort;
        Random rand;

        public sceneControl(ref scene sCene, Rectangle vIewPort)
        {
            rand = new Random();
            scene = sCene;
            textures = sCene.textures;
            viewPort = vIewPort;

            mirrorCount = 2;
            playerCount = 1;
            keyboardPlayer = 5;
            difficulty = 1;
            playerNames = new string[5];
            playerNames[0] = "Player 1";
            playerNames[1] = "Player 2";
            playerNames[2] = "Player 3";
            playerNames[3] = "Player 4";
            playerNames[4] = "Player 5";
        }

        public void loadContents()
        {
            if (playerCount == 5)
            {
                keyboardPlayer = 5;
            }
            for (int x = 1; x <= playerCount; x++)
            {
                player player = new player(textures.players[x - 1], new Rectangle(50, 50, 25, 25), 0f, 5, x);
                player.Color = Color.Blue;

                if (x == 2)
                {
                    player = new player(textures.players[x - 1], new Rectangle(viewPort.Width - 50, 50, 25, 25), 0f, 5, x);
                    player.Color = Color.Red;
                }
                if (x == 3)
                {
                    player = new player(textures.players[x - 1], new Rectangle(50, viewPort.Height - 50, 25, 25), 0f, 5, x);
                    player.Color = Color.Yellow;
                }
                if (x == 4)
                {
                    player = new player(textures.players[x - 1], new Rectangle(viewPort.Width - 50, viewPort.Height - 50, 25, 25), 0f, 5, x);
                    player.Color = Color.Green;
                }
                if (x == 5)
                {
                    player = new player(textures.players[x-1], new Rectangle(viewPort.X + viewPort.Width/2, viewPort.Y + viewPort.Height/2, 25, 25), 0f, 5, x);
                    player.Color = Color.Purple;
                }
                player.name = playerNames[x-1];
                player.health = 80;
                if (keyboardPlayer == x)
                {
                    player.moveWithKeys = true;
                    player.orientOnMouse = true;
                    player.moveWithGamePad = false;
                }
                else
                {
                    player.moveWithGamePad = true;
                    player.moveWithKeys = false; 
                    player.orientOnMouse = false;
                }
                scene.players.Add(player);
            }

            for (int x = 0; x < mirrorCount; x++)
            {
                mirror mirror = new mirror(textures.mirrors[rand.Next(textures.mirrors.Count)], new Rectangle(rand.Next(viewPort.Width-10), rand.Next(viewPort.Height)-20, 8, 150), 0f, 0);
                mirror.Color = new Color(255, 255, 255, 180);
                scene.mirrors.Add(mirror);
            }
        }

    }
}
