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
    class mirror:thingy
    {

        public int carried = -1;
        public int oldCarried = -1;

        private float oldSpeed;

        public mirror(Texture2D ski, Rectangle rect, float rot, float spe)
            : base(ski, rect, rot, spe)
        {
            oldSpeed = spe;
            setDefaults();
        }

        public mirror(Texture2D ski)
            : base(ski)
        {
            setDefaults();
        }

        public mirror(Texture2D ski, Rectangle rect)
            : base(ski, rect)
        {
            setDefaults();
        }

        private void setDefaults()
        {
            getClose = 4f;
        }

        public void mirrorUpdate(ref List<wall> walls, ref List<player> players)
        {




            if (carried != -1)
            {
                oldCarried = carried;
                foreach (player player in players)
                {
                    if (player.PlayerNum == carried)
                    {
                        Rotation = player.Rotation + (float)Math.PI / 2;
                        Speed = player.Speed * 5;

                        float changeX = (float)Math.Cos(player.Rotation) * this.Shape.Height / 2;
                        float changeY = (float)Math.Sin(player.Rotation) * this.Shape.Height / 2;

                        float forwardX = (float)Math.Cos(player.Rotation + Math.PI / 2) * player.Shape.Width * 2 / 4;
                        float forwardY = (float)Math.Sin(player.Rotation + Math.PI / 2) * player.Shape.Width * 2 / 4;

                        Destination = new Vector2(player.center.X + changeX + forwardX, player.center.Y + changeY + forwardY);
                    }
                }
            }

            #region addtolist

            List<thingy> thingys = new List<thingy>();

            foreach (wall wall in walls)
            {
                thingys.Add(wall);
            }


            #endregion
            base.update(ref thingys);
            base.backOffOverlap(ref thingys);

        }
        
    }
}
