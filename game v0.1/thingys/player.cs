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
    class player : thingy
    {
        private int playerNum;
        public int PlayerNum
        {
            get
            {
                return playerNum;
            }
        }

        public string name;

        public int health;
        public Keys lift;
        public Buttons liftPad;
        Random rand = new Random();
        public bool isCarrying = false;
        bool slayerActive = false;
        public int score = 0;
        int scoreTime = 0;

        public PlayerIndex playerIndex = PlayerIndex.One;

        public float oldSpeed;

        private KeyboardState preState;
        private GamePadState prePadState;

        #region //-----------------constructors-----------------------\\

        /// <summary>
        /// Creates a thingy
        /// </summary>
        /// <param name="ski">the texture to put on the thingy</param>
        /// <param name="rect">the shape of the thingy</param>
        /// <param name="rot">the rotation of the thingy</param>
        /// <param name="spe">the speed of the thingy</param>
        public player(Texture2D ski, Rectangle rect, float rot, float spe, int num) :
            base(ski, rect, rot, spe)
        {
            playerNum = num;
            setDefaults();
        }

        /// <summary>
        /// creates a thingy
        /// </summary>
        /// <param name="ski">the texture to put on the thingy</param>
        public player(Texture2D ski, int num) :
            base(ski)
        {
            playerNum = num;
            setDefaults();
        }

        /// <summary>
        /// creates a thingy
        /// </summary>
        /// <param name="ski">the texture to put on the thingy</param>
        /// <param name="rect">the shape of the thingy</param>
        public player(Texture2D ski, Rectangle rect, int num)
            : base(ski, rect)
        {
            playerNum = num;
            setDefaults();
            name = "player " + playerNum;
        }

        private void setDefaults()
        {
            health = 25;
            lift = Keys.LeftShift;

            if (playerNum == 2)
            {
                playerIndex = PlayerIndex.Two;

            }
            if (playerNum == 3)
            {
                playerIndex = PlayerIndex.Three;

            }
            if (playerNum == 4)
            {
                playerIndex = PlayerIndex.Four;

            }

            liftPad = Buttons.RightShoulder;
            prePadState = GamePad.GetState(playerIndex);
            preState = Keyboard.GetState();

            oldSpeed = base.Speed;

        }
        #endregion


        public void playerUpdate(ref List<bullet> bullets, ref List<powerUp> powerUps, ref List<enemy> enemies, ref List<wall> walls, ref  List<mirror> mirrors, SoundBox music)
        {
            #region baseUpdate
            //bullet
            //powerUps
            //enemies
            //walls
            List<thingy> interceptable = new List<thingy>();
            foreach (thingy thingy in powerUps)
            {
                interceptable.Add(thingy);
            }
            foreach (thingy thingy in enemies)
            {
                interceptable.Add(thingy);
            }
            foreach (thingy thingy in walls)
            {
                interceptable.Add(thingy);
            }

            base.update(ref interceptable);
            #endregion
            scoreTime++;
            if (scoreTime % 10 == 0 && isAlive)
            {
                score++;
                scoreTime = 0;
            }
            foreach (enemy enemy in enemies)
            {
                if (slayerActive)
                {
                    if (rand.Next(2) == 1)
                    {
                        enemy.isAlive = false;
                        music.bomb.Play((float)((music.volume/5)*0.5), 0, 0);
                    }
                    
                }
            }
            slayerActive = false;

            foreach (powerUp powerup in powerUps)
            {
                if (this.intercepts(powerup))
                {
                    activatePowerUp(powerup.Poweruptype, music);
                    powerup.isAlive = false;
                }
            }


                bool withKeys = Keyboard.GetState().IsKeyUp(lift) && preState.IsKeyDown(lift) && moveWithKeys;
                bool withPad = GamePad.GetState(playerIndex).IsButtonUp(liftPad) && prePadState.IsButtonDown(liftPad) && moveWithGamePad;
                if (withKeys || withPad)
                {
                    if (isCarrying)
                    {
                        isCarrying = false;
                        foreach (mirror mirror in mirrors)
                        {
                            if (mirror.carried == playerNum)
                            {
                                mirror.carried = -1;
                            }
                        }
                    }
                    else
                    {

                        foreach (mirror mirror in mirrors)
                        {
                            if (this.intercepts(mirror) && mirror.carried == -1 && !isCarrying)
                            {
                                mirror.carried = playerNum;
                                isCarrying = true;
                                mirror.Color = this.Color;
                            }
                        }
                    }
                }
            


            base.backOffOverlap(ref interceptable);

            if (health <= 0)
            {
                isAlive = false;
                base.isCollidable = false;
            }

            preState = Keyboard.GetState();
            prePadState = GamePad.GetState(playerIndex);
        }

        /// <summary>
        /// Created by Daniel Pascucci
        /// 
        /// Activates a powerup that has been picked up
        /// </summary>
        /// <param name="power">The type of powerup picked up</param>
        public virtual void activatePowerUp(powerUp.powerupTypes power, SoundBox musik)
        {
            if (power == powerUp.powerupTypes.hp)
            {
                health += 7;
                musik.health.Play((float)(.3 / 5 * musik.volume), 0, 0);
            }
            else if (power == powerUp.powerupTypes.score)
            {
                score += 100;
                musik.pointAdd.Play((float)(.3/5 * musik.volume), 0, 0);
            }
            else if (power == powerUp.powerupTypes.slayer)
            {
                slayerActive = true;
                musik.slay.Play((float)(.3/5 * musik.volume), 0, 0);
            }
        }

        public override void draw(SpriteBatch batch)
        {
            if (isAlive)
            {
                base.draw(batch);
            }
        }

    }
}
