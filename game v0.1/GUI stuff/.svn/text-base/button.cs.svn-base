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
    class button
    {
        string text;
        Texture2D backGround;
        public Vector2 location;
        MouseState prevState;
        public bool wasPressed;
        SpriteFont font;
        public Rectangle shape
        {
            get
            {
                return new Rectangle((int)location.X, (int)location.Y, (int)font.MeasureString(text).X, (int)font.MeasureString(text).Y);
            }
        }

        public button(string tExt, Texture2D bAckGround, Vector2 loc, SpriteFont fOnt)
        {
            text = tExt;
            backGround = bAckGround;
            location = loc;
            font = fOnt;
            
        }

        public void update()
        {
            if(shape.Intersects(new Rectangle((int)Mouse.GetState().X, (int)Mouse.GetState().Y, 1, 1)) && prevState.LeftButton == ButtonState.Pressed && Mouse.GetState().LeftButton == ButtonState.Released)
            {
                wasPressed = true;
            }
            else
            {
                wasPressed = false;
            }
            prevState = Mouse.GetState();
        }
        public void draw(SpriteBatch batch)
        {
            batch.Draw(backGround, shape, Color.White);
            batch.DrawString(font, text, location, Color.Black);
        }
    }
}
