using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace ChessGame.Input
{
    class ControllerHandler
    {
        #region Member Variables (controllerState, prevControllerState)

        private GamePadState controllerState;
        private GamePadState prevControllerState;

        #endregion

        #region Properties (ControllerState, PreviousControllerState)

        public GamePadState ControllerState
        {
            get { return controllerState; }
        }

        public GamePadState PreviousControllerState
        {
            get { return prevControllerState; }
        }

        #endregion

        public ControllerHandler()
        {
            prevControllerState = GamePad.GetState(PlayerIndex.One);
        }

        #region Button Methods (IsConnected, IsButtonDown, IsHoldingButton, WasButtonPressed, HasReleasedButton)

        public bool IsConnected()
        {
            return GamePad.GetState(PlayerIndex.One).IsConnected;
        }

        public bool IsButtonDown(Microsoft.Xna.Framework.Input.Buttons button)
        {
            return (controllerState.IsButtonDown(button));
        }

        public bool IsHoldingButton(Microsoft.Xna.Framework.Input.Buttons button)
        {
            return (controllerState.IsButtonDown(button) &&
            prevControllerState.IsButtonDown(button));
        }

        public bool WasButtonPressed(Microsoft.Xna.Framework.Input.Buttons button)
        {
            return (controllerState.IsButtonDown(button) &&
            prevControllerState.IsButtonUp(button));
        }

        public bool HasReleasedButton(Microsoft.Xna.Framework.Input.Buttons button)
        {
            return (controllerState.IsButtonUp(button) &&
            prevControllerState.IsButtonDown(button));
        }

        #endregion

        #region Methods (Update)

        public void Update()
        {
            prevControllerState = controllerState;
            controllerState = GamePad.GetState(PlayerIndex.One);
        }

        #endregion
    }
}
