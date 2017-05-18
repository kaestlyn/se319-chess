using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ChessGame.Input
{
    class InputHandler : Microsoft.Xna.Framework.GameComponent, IInputHandler
    {
        #region Member Variables (keyboard, mouse, controller)

        private KeyboardHandler keyboard;
        private MouseHandler mouse;
        private ControllerHandler controller;

        #endregion

        #region Properties (KeyboardState, MouseState, ControllerState)

        public KeyboardHandler KeyboardState
        {
            get { return (keyboard); }
        }
        public MouseHandler MouseState
        {
            get { return (mouse); }
        }

        public ControllerHandler ControllerState
        {
            get { return (controller); }
        }
        #endregion

        public InputHandler(Game game) : base(game)
        {
            // TODO: Construct any child components here
            game.Services.AddService(typeof(IInputHandler), this);
            //initialize our member fields
            keyboard = new KeyboardHandler();
            mouse = new MouseHandler();
            controller = new ControllerHandler();
        }

        #region Public Methods (Initialize, Update)

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            keyboard.Update();
            mouse.Update();
            controller.Update();
            if (keyboard.IsKeyDown(Keys.Escape))
            {
                Game.Exit();
            }

            base.Update(gameTime);
        }

        #endregion
    }
}
