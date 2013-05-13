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
    class bullet : thingy
    {

        public int creditNum = -1;

        private int reflexCounter = 0;

        public int damage = 2;

        public bullet(Texture2D ski, Rectangle rect, float rot, float spe, int dam)
            : base(ski, rect, rot, spe)
        {
            damage = dam;
            base.getClose = 1;
        }

        public bullet(Texture2D ski, int dam)
            : base(ski)
        {
            damage = dam; base.getClose = 1;
        }

        public bullet(Texture2D ski, Rectangle rect, int dam)
            : base(ski, rect)
        {
            damage = dam; base.getClose = 1;
        }


        public bool deadly = false;


        public void bulletUpdate(ref List<enemy> enemies, ref List<mirror> mirrors, ref List<player> players, ref List<wall> walls, SoundBox music)
        {
            if (reflexCounter < 100)
            {
                reflexCounter++;
            }
            #region base update
            List<thingy> thingys = new List<thingy>();

            if (this.deadly)
            {
                foreach (enemy enemy in enemies)
                {
                    thingys.Add(enemy);
                }
            }
            foreach (mirror mirror in mirrors)
            {
                thingys.Add(mirror);
            }
            foreach (player player in players)
            {
                thingys.Add(player);
            }

            foreach (wall wall in walls)
            {
                thingys.Add(wall);
            }
            #endregion

            base.update(ref thingys);

            foreach (thingy thingy in thingys)
            {
                if (thingy is mirror)
                {
                    mirror mirror = (mirror)thingy;
                    if (mirror.intercepts(this))
                    {
                        base.moveForever = false;

                        Rotation += ((float)Math.PI / 2) - 2 * (Rotation - mirror.Rotation);
                        Rotation += (float)Math.PI;

                        base.setDesAhead();

                        if (Shape.Width > Shape.Height)
                        {
                            Shape.Y += (float)Math.Sin(Rotation) * (Shape.Width + 2);
                            Shape.X += (float)Math.Cos(Rotation) * (Shape.Width + 2);
                        }
                        else
                        {
                            Shape.Y += (float)Math.Sin(Rotation) * (Shape.Height + 2);
                            Shape.X += (float)Math.Cos(Rotation) * (Shape.Height + 2);
                        }

                        deadly = true;
                        this.Color = mirror.Color;
                        creditNum = mirror.oldCarried;
                        if (reflexCounter == 100)
                        {
                            music.bounce.Play((float)(.2/5 *music.volume) , 0, 0);
                            reflexCounter = 0;
                        }
                        else
                        {
                            music.bounce.Play((float)(.1 / 5 * music.volume), 0, 0);
                        }

                    }
                }
                else
                {
                    if (this.intercepts(thingy))
                    {
                        isAlive = false;
                        music.bomb.Play((float)(.5 / 5 * music.volume), 0, 0);
                    }
                }
                if (deadly)
                {
                    foreach (enemy enemy in enemies)
                    {
                        if (this.intercepts(enemy))
                        {
                            enemy.Health -= damage;
                            foreach (player player in players)
                            {
                                if (creditNum == player.PlayerNum)
                                {
                                    player.score += 75;
                                }
                            }
                        }
                    }
                }
                foreach (player player in players)
                {
                    if (this.intercepts(player))
                    {
                        player.health -= damage;
                    }
                }
            }
            base.backOffOverlap(ref thingys);

        }
    }
}
