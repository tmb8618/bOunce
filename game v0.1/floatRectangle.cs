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
    class floatRectangle
    {

        private float x;
        private float y;
        private float width;
        private float height;

        public float X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public float Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public float Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        public float Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        public Rectangle roundedRectangle
        {
            get
            {
                return new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
            }
        }

        public floatRectangle(float xx, float yy, float wid, float hei)
        {
            height = hei;
            width = wid;
            x = xx;
            y = yy;
        }

        public floatRectangle(Rectangle rect)
        {
            height = rect.Height;
            width = rect.Width;
            x = rect.X;
            y = rect.Y;
        }




    }
}
