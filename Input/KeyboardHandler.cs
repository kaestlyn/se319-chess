using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace ChessGame.Input
{
    class KeyboardHandler
    {
        #region Member Variables (keyboardState, prevKeyboardState)

        private KeyboardState keyboardState;
        private KeyboardState prevKeyboardState;

        #endregion

        #region Properties

        public KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }

        public KeyboardState PreviousKeyboardState
        {
            get { return prevKeyboardState; }
        }

        #endregion

        public KeyboardHandler()
        {
            prevKeyboardState = Keyboard.GetState();
        }

        #region Public Methods (IsKeyDown, IsHoldingKey, WasKeyPressed, HasReleasedKey, Update)

        public bool IsKeyDown(Keys key)
        {
            return (keyboardState.IsKeyDown(key));
        }

        public bool IsHoldingKey(Keys key)
        {
            return (keyboardState.IsKeyDown(key) &&
            prevKeyboardState.IsKeyDown(key));
        }

        public bool WasKeyPressed(Keys key)
        {
            return (keyboardState.IsKeyDown(key) &&
            prevKeyboardState.IsKeyUp(key));
        }

        public bool HasReleasedKey(Keys key)
        {
            return (keyboardState.IsKeyUp(key) &&
            prevKeyboardState.IsKeyDown(key));
        }

        public void Update()
        {
            //set our previous state to our new state
            prevKeyboardState = keyboardState;
            //get our new state
            keyboardState = Keyboard.GetState();
        }

        #endregion
    }
}
