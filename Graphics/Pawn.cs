using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ChessGame.Objects;
using System.Collections.Generic;

namespace ChessGame.Graphics
{
    class Pawn : Piece
    {
        private bool firstMove;

        public Pawn()
        {
            firstMove = true;
        }

        #region Main Methods (Initialize, CalculateMoves, LoadGraphicsContent, Draw, Update)

        public override void Initialize(Vector2 pos)
        {
            this.pieceNumber = 1;
            base.Initialize(pos);
        }

        public override void CalculateMoves(ChessBoard chessBoard)
        {
            if (isDead)
            {
                // Piece is removed from board, Do nothing
                possibleMoves = null;
            }
            else
            {
                int side = -1;
                if (PlayerIndex != 1)
                {
                    side = 1;
                }

                //Calculate moves here
                possibleMoves = new List<Vector2>();
                int x = (int)currentLocation.X;
                int y = (int)currentLocation.Y;
                if (firstMove)
                {
                    if (validSpace(x, y + side, chessBoard) == 1)
                    {
                        possibleMoves.Add(new Vector2(x, y + side));
                        if (validSpace(x, y + (2 * side), chessBoard) == 1)
                        {
                            possibleMoves.Add(new Vector2(x, y + (2 * side)));
                        }
                    }
                    if (validSpace(x + side, y + side, chessBoard) == 2)
                    {
                        possibleMoves.Add(new Vector2(x + side, y + side));
                    }
                    if (validSpace(x - side, y + side, chessBoard) == 2)
                    {
                        possibleMoves.Add(new Vector2(x - side, y + side));
                    }
                }
                else
                {
                    if (validSpace(x, y + side, chessBoard) == 1)
                    {
                        possibleMoves.Add(new Vector2(x, y + side));
                    }
                    if (validSpace(x + side, y + side, chessBoard) == 2)
                    {
                        possibleMoves.Add(new Vector2(x + side, y + side));
                    }
                    if (validSpace(x - side, y + side, chessBoard) == 2)
                    {
                        possibleMoves.Add(new Vector2(x - side, y + side));
                    }
                }
            }
        }

        public override List<Vector2> CaptureLine(Vector2 location)
        {
            List<Vector2> retValue = new List<Vector2>();
            if (this.possibleMoves.Contains(location))
            {
                if (location.X != this.currentLocation.X)
                {
                    retValue.Add(this.currentLocation);
                }
                //else not a capture move
            }
            return retValue;
        }

        public override void AfterMove()
        {
            firstMove = false;
        }

        #endregion
    }
}
