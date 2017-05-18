using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using ChessGame.Graphics;

namespace ChessGame.Input
{
    class MouseHandler
    {
        #region Member Variables (position, mouseState, prevMouseState)

        private Vector2 position;
        private MouseState mouseState;
        private MouseState prevMouseState;

        #endregion

        #region Properties (MouseState, PreviousMouseState)

        public MouseState MouseState
        {
            get { return mouseState; }
        }

        public MouseState PreviousMouseState
        {
            get { return prevMouseState; }
        }

        #endregion

        public MouseHandler()
        {
            mouseState = Mouse.GetState();
            this.position = Vector2.Zero;
        }

        #region Public Methods (Update, ButtonClick)

        public void Update()
        {
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();
            this.position.X = mouseState.X;
            this.position.Y = mouseState.Y;
        }

        public bool WasLeftButtonPressed()
        {
            if ( prevMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ButtonClick(Image gs)
        {
            if (this.position.X >= gs.Position.X // To the right of the left side
                    && this.position.X < gs.Position.X + gs.Texture.Width //To the left of the right side
                    && this.position.Y > gs.Position.Y //Below the top side
                    && this.position.Y < gs.Position.Y + gs.Texture.Height) //Above the bottom side
            {
                return true; //We are; return true.
            }
            else
            {
                return false; //We're not; return false.
            }
        }

        #endregion
    }
}