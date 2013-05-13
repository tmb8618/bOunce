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
    class selectionList
    {
        int stickDel = 0;

        private bool leftStick;


        int numChoices;
        private int chosenNumber;
        public int ChosenNumber
        {
            get
            {
                return chosenNumber;
            }
        }
        button[] choices;
        string title;
        Vector2 topleft;
        Rectangle pointer;
        SpriteFont font;
        textureBox textures;
        public Color PointerColor = Color.Red;

        public selectionList(int NumberOfOptions, Vector2 tOpLeft, SpriteFont Font, textureBox tex, string tItle, bool lEftStick, int startingElement)
        {
            leftStick = lEftStick;
            numChoices = NumberOfOptions;
            choices = new button[NumberOfOptions];
            chosenNumber =  startingElement-1;
            topleft = tOpLeft;
            font = Font;
            textures = tex;

            int lineSpacing = (int)font.MeasureString("1").Y;
            for (int x = 0; x < choices.Length; x++)
            {
                int text = x+1;
                choices[x] = new button(""+text, tex.defaultTexture, new Vector2(topleft.X, topleft.Y + lineSpacing), font);
                lineSpacing += choices[x].shape.Height;
            }


            pointer = new Rectangle(choices[chosenNumber].shape.X + choices[chosenNumber].shape.Width * 3 / 2, choices[chosenNumber].shape.Y + choices[0].shape.Height / 4, 10, 10);
            
            if (leftStick)
            {
                title = tItle + "(\"left stick\")";
            }
            else
            {
                title = tItle + "(\"right stick\")";
            }
        }

        public void update()
        {
            for (int x = 0; x < choices.Length; x++)
            {
                choices[x].update();
                if (choices[x].wasPressed)
                {
                    pointer = new Rectangle(choices[x].shape.X + choices[x].shape.Width * 3/2, choices[x].shape.Y + choices[0].shape.Height / 4, 10, 10);
                    chosenNumber = x;
                }
            }
            if (leftStick)
            {
                #region left
                if (stickDel == 0)
                {
                    if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0.5 ||
                        GamePad.GetState(PlayerIndex.Two).ThumbSticks.Left.Y > 0.5 ||
                        GamePad.GetState(PlayerIndex.Three).ThumbSticks.Left.Y > 0.5 ||
                        GamePad.GetState(PlayerIndex.Four).ThumbSticks.Left.Y > 0.5
                        )
                    {
                        if (ChosenNumber - 1 >= 0)
                        {
                            chosenNumber -= 1;
                            pointer = new Rectangle(choices[chosenNumber].shape.X + choices[chosenNumber].shape.Width * 3 / 2, choices[chosenNumber].shape.Y + choices[0].shape.Height / 4, 10, 10);

                        }
                    }
                    if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < -0.5 ||
                        GamePad.GetState(PlayerIndex.Two).ThumbSticks.Left.Y < -0.5 ||
                        GamePad.GetState(PlayerIndex.Three).ThumbSticks.Left.Y < -0.5 ||
                        GamePad.GetState(PlayerIndex.Four).ThumbSticks.Left.Y < -0.5)
                    {
                        if (chosenNumber + 1 < choices.Length)
                        {
                            chosenNumber += 1;
                            pointer = new Rectangle(choices[chosenNumber].shape.X + choices[chosenNumber].shape.Width * 3 / 2, choices[chosenNumber].shape.Y + choices[0].shape.Height / 4, 10, 10);

                        }
                    }
                    stickDel = 10;
                }
                if (stickDel > 0)
                {
                    stickDel--;
                }
#endregion
            }
            else
            {
                #region right
                if (stickDel == 0)
                {
                    if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y > 0.5 ||
                        GamePad.GetState(PlayerIndex.Two).ThumbSticks.Right.Y > 0.5 ||
                        GamePad.GetState(PlayerIndex.Three).ThumbSticks.Right.Y > 0.5 ||
                        GamePad.GetState(PlayerIndex.Four).ThumbSticks.Right.Y > 0.5
                        )
                    {
                        if (ChosenNumber-1 >= 0)
                        {
                            chosenNumber -= 1;
                            pointer = new Rectangle(choices[chosenNumber].shape.X + choices[chosenNumber].shape.Width * 3 / 2, choices[chosenNumber].shape.Y + choices[0].shape.Height / 4, 10, 10);

                        }
                    }
                    if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y < -0.5 ||
                        GamePad.GetState(PlayerIndex.Two).ThumbSticks.Right.Y < -0.5 ||
                        GamePad.GetState(PlayerIndex.Three).ThumbSticks.Right.Y < -0.5 ||
                        GamePad.GetState(PlayerIndex.Four).ThumbSticks.Right.Y < -0.5)
                    {
                        if (chosenNumber+1 < choices.Length)
                        {
                            chosenNumber += 1;
                            pointer = new Rectangle(choices[chosenNumber].shape.X + choices[chosenNumber].shape.Width * 3 / 2, choices[chosenNumber].shape.Y + choices[0].shape.Height / 4, 10, 10);
                            
                        }
                    }
                    stickDel = 10;
                
                }
                if (stickDel > 0)
                {
                    stickDel--;
                }
                #endregion
            }
            

        }

        public void draw(SpriteBatch batch)
        {
            batch.DrawString(font, title, topleft, Color.White);
            foreach (button button in choices)
            {
                button.draw(batch);
            }
            batch.Draw(textures.defaultTexture, pointer, PointerColor);
        }
    }
}
