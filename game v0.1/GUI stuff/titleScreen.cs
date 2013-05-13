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
    class titleScreen
    {

        Random rand = new Random();
        textureBox textures;

        public button start;

        private SpriteFont font;

        public int playerCount;
        public int keyboardPlayer;
        public int mirrorCount;


        private selectionList numPlayers;
        private selectionList KeyboardGuy;

        public titleScreen(textureBox tex, SpriteFont fOnt)
        {
            font = fOnt;
            textures = tex;
            start = new button("start (press \"A\")", tex.defaultTexture, new Vector2(5, 350), fOnt);
            playerCount = 1;
            mirrorCount = 2;
            keyboardPlayer = 1;

            numPlayers = new selectionList(5, new Vector2(5, 150), font, tex, "Number of players: ", true, 1);
            KeyboardGuy = new selectionList(5, new Vector2(230, 170), font, tex, "keyboard player: ", false, 1);
            

        }

        public void update()
        {
            start.update();

            #region number of players
            numPlayers.update();
            playerCount = numPlayers.ChosenNumber;
            #endregion

            #region number of mirrors
            mirrorCount = playerCount + 1;
            #endregion

            #region keyboard player
            KeyboardGuy.update();
            keyboardPlayer = KeyboardGuy.ChosenNumber;
            #endregion
            
        }
        public void draw(SpriteBatch batch)
        {
            start.draw(batch);
            numPlayers.draw(batch);
            KeyboardGuy.draw(batch);
            batch.Draw(textures.gameTitle, new Rectangle(0, -10, 500, 150), Color.White);

            batch.DrawString(font, "By: Aleks Litynski, Tyler Brogna, Dan Pascucci, Ian Furry", new Vector2(5, 122), Color.White);
            batch.DrawString(font, "Player 1: Blue \n Player 2: Red \n Player 3: Green \n Player: Yellow \n Player 5: Purple -- Player 5 always uses the Keyboard", new Vector2(5, 375), Color.Wheat);
            batch.DrawString(font, "WASD to move, Shift to pick up mirror. \nFor controller, Right stick to move, left for angle, \nright bumper to pick up. Press \"B\" or ESCAPE for pause", new Vector2(300, 375), Color.Wheat);
            batch.DrawString(font, "GET POWAR UPS!", new Vector2(550, 100), Color.White);
            batch.DrawString(font, "SLAYAR : KILLS EM DEAD", new Vector2(550, 125), Color.Green);
            batch.DrawString(font, "POINT GET!", new Vector2(550, 150), Color.Yellow);
            batch.DrawString(font, "YUM HEALTH!", new Vector2(550, 175), Color.Red);
        }



        public bool shouldStart()
        {
            bool toReturn = false;
            if (start.wasPressed || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
            {
                toReturn = true;
            }
            return toReturn;
        }
    }
}
