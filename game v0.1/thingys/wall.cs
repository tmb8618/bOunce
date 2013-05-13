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
    class wall : thingy
    {

        public wall(Texture2D ski, Rectangle rect, float rot, float spe)
            : base(ski, rect, rot, spe)
        {

        }

        public wall(Texture2D ski)
            : base(ski)
        {

        }

        public wall(Texture2D ski, Rectangle rect)
            : base(ski, rect)
        {

        }
    }
}
