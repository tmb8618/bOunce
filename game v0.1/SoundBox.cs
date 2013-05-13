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
    class SoundBox
    {
        public int volume = 5;
        public SoundEffect bomb;
        public SoundEffect health;

        public SoundEffect slay;
        public SoundEffect pointAdd;

        public SoundEffect bounce;

        public SoundEffect titleMusic;

        public SoundEffect gameMusic;

        public SoundEffect endMusic;

    }
}
