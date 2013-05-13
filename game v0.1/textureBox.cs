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
    class textureBox
    {
        public Texture2D[] players;
        public List<Texture2D> walls;
        public List<Texture2D> enemies;
        public List<Texture2D> mirrors;
        public List<Texture2D> bullets;
        public List<Texture2D> powerUps;
        public List<Texture2D> backGrounds;
        public Texture2D defaultTexture;

        public Texture2D gameTitle;
        public Texture2D gameMakers;

        public textureBox(Texture2D dEfaultTexture)
        {
            defaultTexture = dEfaultTexture;
            players = new Texture2D[5];
            for(int x = 0; x < players.Length; x++)
            {
                players[x] = dEfaultTexture;
            }
            walls = new List<Texture2D>();
            walls.Add(dEfaultTexture);
            enemies = new List<Texture2D>();
            enemies.Add(dEfaultTexture);
            mirrors = new List<Texture2D>();
            mirrors.Add(dEfaultTexture);
            bullets = new List<Texture2D>();
            bullets.Add(dEfaultTexture);
            powerUps = new List<Texture2D>();
            powerUps.Add(dEfaultTexture);
            backGrounds = new List<Texture2D>();
            backGrounds.Add(dEfaultTexture);

            gameTitle = dEfaultTexture;
            gameMakers = dEfaultTexture;
        }
    }
}
