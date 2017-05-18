using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ChessGame.Input;
using System.Windows.Forms;

namespace ChessGame.Objects
{
    class MainMenu
    {
        #region Fields()

        Image background;
        Image banner;

        TextButton play;
        TextButton options;
        TextButton help;
        TextButton quit;

        
        ContentManager content;
        SpriteBatch spriteBatch;

        InputHandler input;

        SpriteFont spriteFont;

        bool playClicked;
        bool quitClicked;
        bool optionsClicked;
        bool optionsReturned;
        bool helpOpen;
        Help helpLauncher;

        #endregion

        #region Properties()

        public bool PlayClicked
        {
            get { return playClicked; }
            set { playClicked = value; }
        }

        public bool QuitClicked
        {
            get { return quitClicked; }
        }

        #endregion

        public MainMenu(InputHandler i)
        {
            playClicked = false;
            quitClicked = false;
            optionsClicked = false;
            optionsReturned = false;
            helpOpen = false;

            input = i;

            background = new Image();
            banner = new Image();

            
            play = new TextButton();
            options = new TextButton();
            help = new TextButton();
            quit = new TextButton();
        }

        #region Main Methods(Initialize, LoadGraphicsContent, Update, Draw)

        public void Initialize(ContentManager content, Game game)
        {
            this.content = content;

            background.Color = Color.White;
            background.Initialize();
            background.Position = new Vector2(0f, 0f);
            background.Layer = 0f;
            background.Size = new Vector2(800f, 600f);
            background.Source = new Rectangle(0, 0, 800, 600);

            banner.Color = Color.White;
            banner.Initialize();
            banner.Position = new Vector2(0f, 60f);
            banner.Layer = 0.5f;
            banner.Size = new Vector2(800f, 100f);
            banner.Source = new Rectangle(0, 0, 800, 100);


            play.Initialize(new Vector2(225f, 300f));
            options.Initialize(new Vector2(225f, 350f));
            help.Initialize(new Vector2(225f, 400f));
            quit.Initialize(new Vector2(225f, 450f));
        }

        public void LoadGraphicsContent(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;

            background.LoadGraphicsContent(spriteBatch, content.Load<Texture2D>(@"Content\ChessSetLight") );
            banner.LoadGraphicsContent(spriteBatch,content.Load<Texture2D>(@"Content\Welcome"));

            play.LoadGraphicsContent(spriteBatch, content.Load<Texture2D>(@"Content\PlayGame"));
            options.LoadGraphicsContent(spriteBatch, content.Load<Texture2D>(@"Content\Options"));
            help.LoadGraphicsContent(spriteBatch, content.Load<Texture2D>(@"Content\Help"));
            quit.LoadGraphicsContent(spriteBatch, content.Load<Texture2D>(@"Content\quit"));

            spriteFont = content.Load<SpriteFont>(@"Content\SpriteFont1");

        }

        public void Update(GameTime gameTime)
        {
            while (optionsReturned == true)
            {
                input.MouseState.Update();
                if (input.MouseState.WasLeftButtonPressed() == false)
                {
                    optionsReturned = false;
                }
            }
            input.MouseState.Update();
            //Update Logic Here
            play.IsHovering = input.MouseState.ButtonClick(play);
            options.IsHovering = input.MouseState.ButtonClick(options);
            help.IsHovering = input.MouseState.ButtonClick(help);
            quit.IsHovering = input.MouseState.ButtonClick(quit);

            if (input.MouseState.WasLeftButtonPressed() && optionsClicked == false )
            {
                if (play.IsHovering)
                {
                    playClicked = true;
                }
                else if (options.IsHovering)
                {
                    optionsClicked = true;
                    Options opt = new Options();
                    opt.ShowDialog();
                    optionsClicked = false;
                    optionsReturned = true;
                }
                else if (help.IsHovering && helpLauncher==null)
                {
                    helpOpen = true;
                    helpLauncher = new Help();
                    helpLauncher.FormClosed +=new FormClosedEventHandler(helpClose);
                    helpLauncher.Show();

                    //helpLauncher.Hide();
                    //helpLauncher.Close();
                    //helpLauncher = null;
                }
                else if (quit.IsHovering)
                {
                    quitClicked = true;
                }
            }

        }
        public void helpClose(object sender, FormClosedEventArgs e)
        {
            helpLauncher = null;
        }
        public void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            background.Draw(gameTime);
            banner.Draw(gameTime);

            play.Draw(gameTime);
            options.Draw(gameTime);
            help.Draw(gameTime);
            quit.Draw(gameTime);

            spriteBatch.DrawString(spriteFont, "Version: 1.0", new Vector2(690, 575), Color.White);

            spriteBatch.End();
        }

        #endregion
    }
}
