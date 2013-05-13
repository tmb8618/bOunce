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
    class pauseMenu
    {
        public selectionList musicVolume;
        public selectionList gameVolume;
        public button unPause;

        public pauseMenu(SpriteFont font, textureBox tex)
        {
            musicVolume = new selectionList(10, new Vector2(5, 5), font, tex, "Music volume", true, 5);
            gameVolume = new selectionList(10, new Vector2(150, 20), font, tex, "Game volume", false, 5);
            unPause = new button("Unpause (\"Y\")", tex.defaultTexture, new Vector2(5, 300), font);
        }
        public void update()
        {
            musicVolume.update();
            gameVolume.update();
            unPause.update();
        }
        public void draw(SpriteBatch batch)
        {
            musicVolume.draw(batch);
            gameVolume.draw(batch);
            unPause.draw(batch);
        }
    }
}
