using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

using ChessGame.Objects;
using ChessGame.Input;

namespace ChessGame
{
    /// <summary>
    /// Current State of the application, basically whether or
    /// not a game is running, or if we are in the menu.
    /// </summary>
    enum GameState
    {
        Menu,
        Game
    }

    
    /// <summary>
    /// Chess Game Engine
    /// </summary>
    public class Engine : Microsoft.Xna.Framework.Game
    {
        #region Fields (graphics, spriteBatch, board, content)

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ContentManager content;

        ChessBoard board;
        MainMenu menu;

        GameState gameState;
        
        int endOfGame;
        
        InputHandler input;

        #endregion

        public Engine()
        {

            graphics = new GraphicsDeviceManager(this);
            this.IsMouseVisible = true;
            Content.RootDirectory = "Content";
            this.content = new ContentManager(this.Services);
            input = new InputHandler(this);
            menu = new MainMenu(input);
            
            // TODO: Remove this Later
            gameState = GameState.Menu; //GameState.Game;
        }

        #region Main Methods (Initialize, LoadContent, UnloadContent, Update, Draw)

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            menu.Initialize(content, this);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            menu.LoadGraphicsContent(spriteBatch);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            if (gameState == GameState.Game)
            {
                if (board.IsGameOver && board.IsGameQuit == false)
                {
                    if (endOfGame == 0)
                    {
                        endOfGame = gameTime.TotalGameTime.Seconds;
                    }
                    else
                    {
                        if (endOfGame + 3 < gameTime.TotalGameTime.Seconds)
                        {
                            endOfGame = 0;
                            System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("Would you like to start a new game?", "New Game", System.Windows.Forms.MessageBoxButtons.YesNo);
                            if (result.Equals(System.Windows.Forms.DialogResult.Yes))
                            {
                                board = null;
                                gameState = GameState.Game;
                                CreateChessGame();
                            }
                            else
                            {
                                board = null;
                                gameState = GameState.Menu;
                            }
                        }
                    }
                }
                else if (board.IsGameQuit)
                {
                    System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("Would you like to start a new game?", "New Game", System.Windows.Forms.MessageBoxButtons.YesNo);
                    if (result.Equals(System.Windows.Forms.DialogResult.Yes))
                    {
                        board = null;
                        gameState = GameState.Game;
                        CreateChessGame();
                    }
                    else
                    {
                        board = null;
                        gameState = GameState.Menu;
                    }
                }
                else
                {
                    board.Update(gameTime);
                }
            }
            else if (gameState == GameState.Menu)
            {
                if (menu.PlayClicked)
                {
                    //Reset Game Then Start it
                    gameState = GameState.Game;
                    menu.PlayClicked = false;
                    CreateChessGame();
                }
                else if (menu.QuitClicked)
                {
                    this.Exit();
                }
                menu.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            if (gameState == GameState.Game)
            {
                board.Draw(gameTime);
            }
            else if (gameState == GameState.Menu)
            {
                menu.Draw(gameTime);
            }

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        #endregion

        #region Private Methods

        private void CreateChessGame()
        {
            CreateBoard();
            InitializeBoard();
            LoadGraphicsContentBoard();
        }

        private void InitializeBoard()
        {
             board.Initialize(content, this);
        }

        private void LoadGraphicsContentBoard()
        {
            board.LoadGraphicsContent(spriteBatch);
        }

        private void CreateBoard()
        {
            board = new ChessBoard(input);
        }

        #endregion
    }
}