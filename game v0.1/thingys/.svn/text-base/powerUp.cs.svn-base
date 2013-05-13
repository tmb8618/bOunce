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
    class powerUp : thingy
    {
        public enum powerupTypes { hp, score, slayer };
        public powerupTypes Poweruptype;

        public powerUp(Texture2D ski, Rectangle rect, float rot, float spe, powerupTypes type)
            : base(ski, rect, rot, spe)
        {
            setDefaults(type);
        }

        public powerUp(Texture2D ski, powerupTypes type)
            : base(ski)
        {
            setDefaults(type);
        }

        public powerUp(Texture2D ski, Rectangle rect, powerupTypes type)
            : base(ski, rect)
        {
            setDefaults(type);
        }

        private void setDefaults(powerupTypes type)
        {
            Poweruptype = type;
            backOffAuto = false;
        }

    }
}
