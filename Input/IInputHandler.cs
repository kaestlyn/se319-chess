using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ChessGame.Input
{
    interface IInputHandler
    {
        KeyboardHandler KeyboardState { get; }
        MouseHandler MouseState { get; }
    };
}
