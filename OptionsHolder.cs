using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics; 

namespace ChessGame
{
    class OptionsHolder
    {
        private static Color player1color= Color.White;
        private static Color player2color= Color.Gray;
        private static bool highlightMoves=true;

        public static Color Player1Color
        {
            get {return player1color;}
            set { player1color = value; }
        }
        public static Color Player2Color
        {
            get { return player2color; }
            set { player2color = value; }
        }
        public static bool HighlightMoves
        {
            get { return highlightMoves; }
            set { highlightMoves = value; }
        }

    }
}
