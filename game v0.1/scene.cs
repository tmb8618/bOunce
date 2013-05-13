using System;
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
    class scene
    {
        int totObjects = 40;
        int totEnemies = 6;

        public List<player> players = new List<player>();
        public List<bullet> bullets = new List<bullet>();
        public List<enemy> enemies = new List<enemy>();
        public List<mirror> mirrors = new List<mirror>();
        public List<powerUp> powerUps = new List<powerUp>();
        public List<wall> walls = new List<wall>();
        SoundBox soundFEX;

        public textureBox textures;

        public Rectangle viewPortBounds;
        int enemyTimer;
        int powerUpTimer;

        

        Random rand;

        public scene(player pla, ref textureBox tExtures, SoundBox sfx)
        {
            textures = tExtures;
            players.Add(pla);
            viewPortBounds = new Rectangle();
            enemyTimer = 0;
            powerUpTimer = 0;
            rand = new Random();
            soundFEX = sfx;
        }
        public scene(ref textureBox tExtures,SoundBox sfx)
        {
            textures = tExtures;
            rand = new Random();
            viewPortBounds = new Rectangle();
            enemyTimer = 0;
            powerUpTimer = 0;
            soundFEX = sfx;
        }



        public void update(GameTime gameTime)
        {
            
            enemyTimer++;
            powerUpTimer++;

            spawnUpdate();

            for (int x = 0; x < powerUps.Count; x++)
            {
                
                if (!powerUps[x].isAlive)
                {
                    powerUps.Remove(powerUps[x]);
                    
                }
            }
            for (int x = 0; x < bullets.Count; x++)
            {
                bullets[x].bulletUpdate(ref enemies, ref mirrors, ref players, ref walls, soundFEX);

                if(bullets[x].topLeft.X < 0 || bullets[x].topLeft.Y < 0 || bullets[x].topLeft.X > viewPortBounds.Width || bullets[x].topLeft.Y > viewPortBounds.Height)
                {
                    bullets[x].isAlive = false;
                }
                if (!bullets[x].isAlive)
                {
                    bullets.Remove(bullets[x]);
                }
            }
            for (int x = 0; x < mirrors.Count; x++)
            {
                mirrors[x].mirrorUpdate(ref walls, ref players);

                if (!mirrors[x].isAlive)
                {
                    mirrors.Remove(mirrors[x]);
                }
            }
            for (int x = 0; x < walls.Count; x++)
            {
                if (!walls[x].isAlive)
                {
                    walls.Remove(walls[x]);
                }
            }
            for (int x = 0; x < enemies.Count; x++)
            {
                #region fire bullets and target player. TYLER REPLACE THIS!!!!
                int divNum = mirrors.Count;
                if (divNum == 0)
                {
                    divNum++;
                }
                if (enemyTimer % 150 == 0 && bullets.Count + enemies.Count + players.Count < (totObjects/divNum)*2)
                {
                    bullets.Add(enemies[x].fireBullet(players));
                }
                foreach (player player in players)
                {
                    if (player.PlayerNum == enemies[x].Target)
                    {
                        enemies[x].Destination = player.center;
                    }
                }
                #endregion

                enemies[x].enemyUpdate(ref bullets, ref mirrors, ref walls, ref enemies, ref players);
                if (!enemies[x].isAlive)
                {
                    enemies.Remove(enemies[x]);
                }
            }
            int livePlayer = 0;
            for (int x = 0; x < players.Count; x++)
            {
                players[x].playerUpdate(ref bullets, ref powerUps, ref enemies, ref walls, ref mirrors, soundFEX);

                if (players[x].health <= 0)
                {
                    players[x].isCarrying = false;
                    players[x].Color = new Color(players[x].Color.R, players[x].Color.G, players[x].Color.B, players[x].Color.A / 5);
                    foreach (mirror mirror in mirrors)
                    {
                        if (mirror.oldCarried == players[x].PlayerNum)
                        {
                            mirror.carried = -1;
                            mirror.Color = new Color(255, 255, 255, 180);
                            mirror.oldCarried = -1;
                        }
                    }

                }
                else
                {
                    livePlayer++;
                }
            }
            
            if (mirrors.Count > livePlayer+1)
            {
                mirrors.Remove(mirrors[0]);
            }
        }
        /// <summary>
        /// Created by Daniel Pascucci
        /// 
        /// Very simple method that chooses when to spawn enemies and powerups
        /// </summary>
        private void spawnUpdate()
        {
            if (powerUpTimer == 180)
            {
                spawnPowerup();
                powerUpTimer = 0;
            }
            if (enemyTimer == 100)
            {
                if (enemies.Count < totEnemies)
                {
                    spawnEnemy();
                }
                enemyTimer = 0;
            }
        }

        /// <summary>
        /// Created by Daniel Pascucci
        /// 
        /// Spawns a random powerup at a random spot on the screen, 
        /// while avoiding spawning into a wall
        /// </summary>
        private void spawnPowerup()
        {
            int powerUpSize = 10;
            int powerUpSkin = rand.Next(textures.powerUps.Count);
            powerUp powerUpToSpawn = new powerUp(textures.powerUps[powerUpSkin], new Rectangle(1, 1, powerUpSize, powerUpSize), powerUp.powerupTypes.hp);
            bool noCollision = true;
            int typeChooser;
            while (true)
            {
                noCollision = true;
                // Chooses which type of powerup to spawn
                typeChooser = rand.Next(12);
                    if(typeChooser <= 5)
                    {
                        powerUpToSpawn = new powerUp(textures.powerUps[powerUpSkin], new Rectangle(rand.Next(viewPortBounds.Width), rand.Next(viewPortBounds.Height), powerUpSize, powerUpSize), powerUp.powerupTypes.hp);
                        powerUpToSpawn.Color = Color.Red;
                    }
                    else if(typeChooser <= 10 && typeChooser > 5){
                        powerUpToSpawn = new powerUp(textures.powerUps[powerUpSkin], new Rectangle(rand.Next(viewPortBounds.Width), rand.Next(viewPortBounds.Height), powerUpSize, powerUpSize), powerUp.powerupTypes.score);
                        powerUpToSpawn.Color = Color.Yellow;
                    }
                    else if (typeChooser == 11)
                    {
                        powerUpToSpawn = new powerUp(textures.powerUps[powerUpSkin], new Rectangle(rand.Next(viewPortBounds.Width), rand.Next(viewPortBounds.Height), powerUpSize, powerUpSize), powerUp.powerupTypes.slayer);
                        powerUpToSpawn.Color = Color.LimeGreen;
                    }
                
                // Ensures powerup does not spawn into a wall
                foreach (wall x in walls)
                {
                    if (powerUpToSpawn.intercepts(x))
                        noCollision = false;
                }
                if (noCollision)
                {
                    powerUpToSpawn.Rotation += (float)rand.NextDouble() * 2;
                    powerUps.Add(powerUpToSpawn);
                    break;
                }
            }
        }

        /// <summary>
        /// Created by Daniel Pascucci
        /// 
        /// Portion of code that chooses which type of enemy to spawn added by Alex Litynski
        /// 
        /// Method chooses location and type of enemy to spawn, and adds it to the game
        /// </summary>
        private void spawnEnemy()
        {
            int quadrant = rand.Next(4);
            enemy enemy1;
            int textureChoice = rand.Next(textures.enemies.Count);
            int x = 0, y = 0;
            switch (quadrant)
            {
                // Chooses which side of the screen to spawn off of, and where to spawn it off that side
                case 0:
                    y = -25;
                    x = rand.Next(viewPortBounds.Width);
                    break;
                case 1:
                    y = rand.Next(viewPortBounds.Height);
                    x = viewPortBounds.Width + 25;
                    break;
                case 2:
                    y = viewPortBounds.Height + 25;
                    x = rand.Next(viewPortBounds.Width);
                    break;
                case 3:
                    y = rand.Next(viewPortBounds.Height);
                    x = -25;
                    break;
            }
            int bulletSkin = rand.Next(textures.bullets.Count);
            // Chooses random attributes for the enemy
            enemy1 = new enemy(textures.enemies[textureChoice], new Rectangle(x, y, rand.Next(20) + 10, rand.Next(20) + 10), 0f, 0.05f, textures.bullets[bulletSkin], new Rectangle(0, 0, rand.Next(4)+1, rand.Next(13)+1), 2f, 5);
            enemy1.Speed = (float)rand.NextDouble() + 0.7f;
            enemy1.BulletSpeed = 2*(float)rand.NextDouble() + (float)rand.NextDouble() + enemy1.Speed;
            enemy1.BulletDamage = rand.Next(2,8);
            enemy1.Target = rand.Next(1, players.Count+1);
            enemy1.Health = rand.Next(3, 15);
            enemy1.Color = Color.White;
            enemies.Add(enemy1);
        }

        public void draw(SpriteBatch batch)
        {
            if (textures.backGrounds.Count > 0)
            {
                batch.Draw(textures.backGrounds[rand.Next(textures.backGrounds.Count)], viewPortBounds, Color.White);
            }
            foreach (powerUp powerUp in powerUps)
            {
                powerUp.draw(batch);
            }
            foreach (bullet bullet in bullets)
            {
                bullet.draw(batch);
            }
            foreach (enemy enemy in enemies)
            {
                enemy.draw(batch);
                #region display health
                //change rowsize to change the size of each row. Spacing is done automagically
                int erowSize = 2;
                int elines = 0;
                int ehealth = enemy.Health;
                while(ehealth > 0)
                {
                    if (erowSize / 3 > 0)
                    {
                        elines += erowSize + erowSize / 3;
                    }
                    else
                    {
                        elines += erowSize + 1;
                    }
                    if (ehealth - enemy.Shape.Width > 0)
                    {
                        batch.Draw(textures.defaultTexture, new Rectangle(enemy.boundingBox.X, enemy.boundingBox.Y + enemy.boundingBox.Height + elines, (int)enemy.Shape.Width, erowSize), Color.Red);
                    }
                    else
                    {
                        batch.Draw(textures.defaultTexture, new Rectangle(enemy.boundingBox.X, enemy.boundingBox.Y + enemy.boundingBox.Height + elines, ehealth, erowSize), Color.Red);

                    }
                    ehealth -= (int)enemy.Shape.Width;
                }
                #endregion
            }
            foreach (mirror mirror in mirrors)
            {
                mirror.draw(batch);
            }
            foreach (player player in players)
            {
                player.draw(batch);
                #region display health
                //change rowsize to change the size of each row. Spacing is done automagically
                int rowSize = 2;
                int lines = 0;
                int health = player.health;
                while (health > 0)
                {
                    if (rowSize / 3 > 0)
                    {
                        lines += rowSize + rowSize / 3;
                    }
                    else
                    {
                        lines += rowSize + 1;
                    }
                    if (health - player.Shape.Width > 0)
                    {
                        batch.Draw(textures.defaultTexture, new Rectangle(player.boundingBox.X, player.boundingBox.Y + player.boundingBox.Height + lines, (int)player.Shape.Width, rowSize), Color.Red);
                    }
                    else
                    {
                        batch.Draw(textures.defaultTexture, new Rectangle(player.boundingBox.X, player.boundingBox.Y + player.boundingBox.Height + lines, health, rowSize), Color.Red);

                    }
                    health -= (int)player.Shape.Width;
                }
                #endregion
                
            }
            foreach (wall wall in walls)
            {
                wall.draw(batch);
            }
        }
    }
}
