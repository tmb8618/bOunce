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

    public enum gameState
    {
        title,end,game
    }
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class game : Microsoft.Xna.Framework.Game
    {
        bool paused;
        pauseMenu pauseScreen;

        gameState state = gameState.title;

        #region just don't look
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        protected override void Initialize() { base.Initialize(); }
        protected override void UnloadContent() { }
        GameTime gameTime;
        public game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;
            IsMouseVisible = true;
            this.graphics.PreferredBackBufferHeight = 500;//GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            this.graphics.PreferredBackBufferWidth = 800;//GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
           // this.graphics.IsFullScreen = true;
            this.IsFixedTimeStep = true;
            TargetElapsedTime = new TimeSpan(10000000L / 60L);
            gameTime = new GameTime();
            
        }
        #endregion

        Texture2D pixel;
        SpriteFont font;
        scene currentScene;
        SoundBox soundFX;
        SoundEffectInstance [] gameTechno = new SoundEffectInstance[3];
        Random rand = new Random();
        button softReset, hardReset;

        #region test
        highScore highScoreManager;
        textureBox textures;
        sceneControl sceneController;
        titleScreen title;
        bool scoreNotComputed;
        #endregion

        protected override void LoadContent()
        {
            Window.Title = "b0unce";
            paused = false;

            spriteBatch = new SpriteBatch(GraphicsDevice);
            pixel = Content.Load<Texture2D>("pixel");
            font = Content.Load<SpriteFont>("font");
            scoreNotComputed = true;
            soundFX = new SoundBox();




            #region adds all textures to the textureBox
            textures = new textureBox(pixel);
            textures.backGrounds = new List<Texture2D>();

            int blah = rand.Next(7) + 1;
            string ext = "backgrounds/b"+blah;
            textures.backGrounds.Add(Content.Load<Texture2D>(ext));

            textures.enemies = new List<Texture2D>();
            textures.enemies.Add(Content.Load<Texture2D>("enemy2"));
            textures.enemies.Add(Content.Load<Texture2D>("enemy3"));
            textures.enemies.Add(Content.Load<Texture2D>("enemy4"));

            textures.powerUps = new List<Texture2D>();
            textures.powerUps.Add(Content.Load<Texture2D>("powerUp"));

            textures.players = new Texture2D[5];
            for (int x = 0; x < textures.players.Length; x  ++ )
            {
                textures.players[x] = Content.Load<Texture2D>("player");
            }

            textures.gameMakers = Content.Load<Texture2D>("credits");
            textures.gameTitle = Content.Load<Texture2D>("title");
            #endregion

            soundFX.bomb = Content.Load<SoundEffect>("Sound/bomb-02");
            soundFX.slay = Content.Load<SoundEffect>("Sound/Slayer");
            soundFX.health = Content.Load<SoundEffect>("Sound/Health");
            soundFX.pointAdd = Content.Load<SoundEffect>("Sound/Points");
            soundFX.bounce = Content.Load<SoundEffect>("Sound/scifi034");

            soundFX.titleMusic = Content.Load<SoundEffect>("Sound/mainTheme");
            soundFX.gameMusic = Content.Load<SoundEffect>("Sound/gameTheme");
            soundFX.endMusic = Content.Load<SoundEffect>("Sound/deathTheme");


            gameTechno[0] = soundFX.titleMusic.CreateInstance();
            gameTechno[1] = soundFX.gameMusic.CreateInstance();
            gameTechno[2] = soundFX.endMusic.CreateInstance();
            for (int x = 0; x < gameTechno.Length; x++)
            {
                gameTechno[x].Volume = 0.4f;
            }
            
            

            currentScene = new scene(ref textures, soundFX);

            sceneController = new sceneControl(ref currentScene, new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            sceneController.keyboardPlayer = 2;
            sceneController.mirrorCount = 2;
            sceneController.playerCount = 2;
            sceneController.loadContents();

            highScoreManager = new highScore(currentScene.players);
            title = new titleScreen(textures, font);

            hardReset = new button("title screen (press \"start\")", textures.defaultTexture, new Vector2(GraphicsDevice.Viewport.Width / 2 - 200, 430), font);
            softReset = new button("restart (press \"select\")", textures.defaultTexture, new Vector2(GraphicsDevice.Viewport.Width / 2 + 20, 430), font);


            pauseScreen = new pauseMenu(font, textures);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)
                || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.B)
                || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.B)
                || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.B)
                || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.B))
            {
                paused = true;
            }
            hardReset.location = new Vector2(GraphicsDevice.Viewport.Width / 2 - 200, 430);
            softReset.location = new Vector2(GraphicsDevice.Viewport.Width / 2 + 20, 430);

            #region check if game over
            base.Update(gameTime);
            bool gameOver = true;
            foreach (player player in currentScene.players)
            {
                if (player.health > 0)
                {
                    gameOver = false ;
                }
            }
            if (gameOver)
            {
                state= gameState.end;
            }
            #endregion

            if (!paused)
            {
                if (state == gameState.game)
                {
                    if (gameTechno[1].State != SoundState.Playing)
                    {
                        gameTechno[0].Stop();
                        gameTechno[2].Stop();
                        gameTechno[1].Play(); 
                    }
                    currentScene.update(gameTime);
                    currentScene.viewPortBounds = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
                }
                if (state == gameState.end)
                {
                    hardReset.update(); softReset.update();
                    if (gameTechno[2].State != SoundState.Playing)
                    {
                        gameTechno[0].Stop();
                        gameTechno[1].Stop();
                        gameTechno[2].Play();
                    }
                }
                if (state == gameState.title)
                {
                    if (gameTechno[0].State != SoundState.Playing)
                    {
                        gameTechno[1].Stop();
                        gameTechno[2].Stop();
                        gameTechno[0].Play();
                    }
                    title.update();
                    if (title.shouldStart())
                    {
                        state = gameState.game;
                        currentScene = new scene(ref textures, soundFX);
                        sceneController.scene = currentScene;
                        sceneController.playerCount = title.playerCount+1;
                        sceneController.mirrorCount = title.mirrorCount+1;
                        sceneController.keyboardPlayer = title.keyboardPlayer+1;
                        sceneController.loadContents();
                        highScoreManager = new highScore(currentScene.players);
                    }
                }
            }
            else
            {
                pauseScreen.update();
                hardReset.update(); softReset.update();
                if (pauseScreen.unPause.wasPressed
                || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Y)
                || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Y)
                || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Y)
                || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Y))
                {
                    paused = false;
                }
            }
            gameTechno[0].Volume = 0.1f * pauseScreen.musicVolume.ChosenNumber;
            gameTechno[1].Volume = 0.1f * pauseScreen.musicVolume.ChosenNumber;
            gameTechno[2].Volume = 0.1f * pauseScreen.musicVolume.ChosenNumber;
            

            if (state == gameState.end || paused)
            {
                #region soft reset
                if (softReset.wasPressed ||
                    GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Back)
                    || GamePad.GetState(PlayerIndex.Two).IsButtonDown(Buttons.Back)
                    || GamePad.GetState(PlayerIndex.Three).IsButtonDown(Buttons.Back)
                    || GamePad.GetState(PlayerIndex.Four).IsButtonDown(Buttons.Back))
                {
                    highScoreManager = new highScore(currentScene.players);
                    scoreNotComputed = true;
                    currentScene = new scene(ref textures, soundFX);
                    sceneController.scene = currentScene;
                    sceneController.loadContents();
                    state = gameState.game;
                    gameTechno[2].Stop();
                    hardReset = new button("title screen (press \"start\")", textures.defaultTexture, new Vector2(GraphicsDevice.Viewport.Width / 2 - 200, 430), font);
                    softReset = new button("restart (press \"select\")", textures.defaultTexture, new Vector2(GraphicsDevice.Viewport.Width / 2 + 20, 430), font);
                    paused = false;
                }
                #endregion
                #region hard reset
                if (//Keyboard.GetState().IsKeyDown(Keys.M)
                    hardReset.wasPressed ||
                    GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Start)
                    || GamePad.GetState(PlayerIndex.Two).IsButtonDown(Buttons.Start)
                    || GamePad.GetState(PlayerIndex.Three).IsButtonDown(Buttons.Start)
                    || GamePad.GetState(PlayerIndex.Four).IsButtonDown(Buttons.Start))
                {
                    gameTechno[2].Stop();
                    LoadContent();
                    state = gameState.title;

                }
                #endregion
            }
            soundFX.volume = pauseScreen.gameVolume.ChosenNumber;
        }


        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Draw(textures.backGrounds[0], new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);


            if (state == gameState.game)
            {
                currentScene.draw(spriteBatch);
            }
            if (state == gameState.end)
            {
                hardReset.draw(spriteBatch);
                softReset.draw(spriteBatch);
                #region high score
                if (scoreNotComputed)
                {
                    highScoreManager = new highScore(currentScene.players);
                    highScoreManager.readScoreList("HighScore.txt");
                    highScoreManager.computeNewScoreList();
                    highScoreManager.writeScoreList("HighScore.txt");
                }
                spriteBatch.DrawString(font, highScoreManager.highestScorePlayerName + " won with a score of " + highScoreManager.highestPlayerScore, new Vector2(GraphicsDevice.Viewport.Width / 2 - 125, 400), Color.White);
                for (int i = 0; i < highScoreManager.playerScores.Count; i++)
                {
                    if (i < highScoreManager.playerScoreRankings.Count && highScoreManager.playerScoreRankings[i] != null)
                    {
                        spriteBatch.DrawString(font, highScoreManager.playerScoreRankings[i] + " with a score of " + highScoreManager.playerScores[i], new Vector2(50, (GraphicsDevice.Viewport.Height / 4) + (50 * i)), Color.White);
                    }
                }
                scoreNotComputed = false;
                #endregion


                spriteBatch.DrawString(font, "Music: ZachPayne - Dream Trance: Daydream, DJ Splash - Days Gone By, SomoN - Zul`jin : Death Techno ", new Vector2(5, GraphicsDevice.Viewport.Height - 20), Color.White);

            }
            if (state == gameState.title)
            {
                title.draw(spriteBatch);
            }

            if (state != gameState.title)
            {
                #region display score during game
                int lineNum = 0;
                foreach (player player in currentScene.players)
                {
                    spriteBatch.DrawString(font, "Player " + player.PlayerNum + " score: " + player.score, new Vector2(GraphicsDevice.Viewport.Width / 2 - 75, lineNum), Color.White);
                    lineNum += 15;

                }
                #endregion
            }

            if (paused)
            {
                spriteBatch.Draw(textures.defaultTexture, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), new Color(0, 0, 0, 150));
                pauseScreen.draw(spriteBatch);

                hardReset.draw(spriteBatch);
                softReset.draw(spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

