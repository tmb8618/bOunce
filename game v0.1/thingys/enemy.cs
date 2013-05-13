using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    class enemy:thingy
    {
        #region variables

        Random rand = new Random();
        private int target;
        public int Target
        {
            get 
            {
                return target;
            }
            set 
            { 
                target = value; 
            }
        }

        private int health;
        private int maxHp;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value > health)
                {
                    maxHp = value;
                }
                health = value;
                
            }
        }

        private Texture2D bulletSkin;
        public Texture2D BulletSkin
        {
            get
            {
                return bulletSkin;
            }
            set
            {
                bulletSkin = value;
            }
        }
        private floatRectangle bulletShape;
        public floatRectangle BulletShape
        {
            get
            {
                return bulletShape;
            }
            set
            {
                bulletShape = value;
            }
        }
        private float bulletSpeed;
        public float BulletSpeed
        {
            get
            {
                return bulletSpeed;
            }
            set
            {
                bulletSpeed = value;
            }
        }
        private int bulletDamage;
        public int BulletDamage
        {
            get
            {
                return bulletDamage;
            }
            set
            {
                bulletDamage = value;
            }
        }



#endregion

        public enemy(Texture2D ski, Rectangle rect, float rot, float spe, Texture2D bulSki, Rectangle bulSha, float bulSpe, int bulDam)
            : base(ski, rect, rot, spe)
        {
            bulletShape = new floatRectangle(bulSha);
            bulletSkin = bulSki;
            bulletSpeed = bulSpe;
            bulletDamage = bulDam;
            setDefaults();
        }

        public enemy(Texture2D ski, Texture2D bulSki, Rectangle bulSha, float bulSpe, int bulDam)
            : base(ski)
        {
            bulletShape = new floatRectangle(bulSha);
            bulletSkin = bulSki;
            bulletSpeed = bulSpe;
            bulletDamage = bulDam;
            setDefaults();
        }

        public enemy(Texture2D ski, Rectangle rect, Texture2D bulSki, Rectangle bulSha, float bulSpe, int bulDam)
            : base(ski, rect)
        {
            bulletShape = new floatRectangle(bulSha);
            bulletSkin = bulSki;
            bulletSpeed = bulSpe;
            bulletDamage = bulDam;
            setDefaults();
        }

        private void setDefaults()
        {
            target = 1;
            health = 10;
            maxHp = health;
            rand = new Random();
            orientOnDestination = true;
        }



        public void enemyUpdate(ref List<bullet> bullets, ref List<mirror> mirrors, ref List<wall> walls, ref List<enemy> enemies, ref List<player> players)
        {
            #region base update
            List<thingy> thingys = new List<thingy>();
            foreach (mirror mirror in mirrors)
            {
                thingys.Add(mirror);
            }
            foreach (bullet bullet in bullets)
            {
                if (bullet.deadly)
                {
                    thingys.Add(bullet);
                }
            }
            foreach (wall wall in walls)
            {
                thingys.Add(wall);
            }
            foreach (enemy enemy in enemies)
            {
                thingys.Add(enemy);
            }
            foreach (player player in players)
            {
                thingys.Add(player);
                if (player.health <= 0 && player.PlayerNum == Target)
                {
                    Target = rand.Next(1, players.Count + 1);
                }
            }
            base.update(ref thingys);
            #endregion


            base.backOffOverlap(ref thingys);

            if (health <= 0)
            {
                isAlive = false;
            }
        }


        public bullet fireBullet(List<player> players)
        {
            bool hasATarget = false;
            bullet toReturn = new bullet(bulletSkin, 0);
            foreach (player player in players)
            {
                if (player.PlayerNum == target)
                {
                    player dest = player;

                    float angle = (float)Math.Atan2(dest.center.Y - this.center.Y, dest.center.X - this.center.X);

                    bulletShape = new floatRectangle(this.center.X, this.center.Y, bulletShape.Width, bulletShape.Height);
                    bullet temp = new bullet(bulletSkin, bulletShape.roundedRectangle, angle, bulletSpeed, bulletDamage);


                    temp.orientOnDestination = true;
                    temp.setDesAhead();
                    temp.moveForever = false;


                    temp.Color = new Color(255, 255, 255, 180);
                    hasATarget = true;
                    temp.isAlive = true;

                    

                    toReturn = temp;

                }
                else
                {
                    if (!hasATarget)
                    {
                        toReturn.isAlive = false;
                    }
                }

            }
            return toReturn;
        }
    }
}
