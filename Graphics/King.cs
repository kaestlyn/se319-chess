using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ChessGame.Graphics
{
    class King : Piece
    {
        private bool firstMove;

        public King()
        {
            firstMove = true;
        }

        public bool HasMoved
        {
            get { return !firstMove; }
        }

        #region Main Methods (Initialize, LoadGraphicsContent, Draw, Update)

        public override void Initialize(Vector2 pos)
        {
            this.pieceNumber = 4;
            base.Initialize(pos);
        }


        public override void AfterMove()
        {
            firstMove = false;
        }

        public override void CalculateMoves(ChessGame.Objects.ChessBoard chessBoard)
        {
            possibleMoves = new List<Vector2>();
            if (isDead)
            {
                possibleMoves = null;
            }
            else
            {
                if (firstMove && currentLocation.X == 4)
                {
                    bool leftOne = validSpace(currentLocation.X + 1, currentLocation.Y, chessBoard) == 1;
                    bool leftTwo = validSpace(currentLocation.X + 2, currentLocation.Y, chessBoard) == 1;
                    bool leftThree = validSpace(currentLocation.X + 3, currentLocation.Y, chessBoard) == 0;
                    bool rightOne = validSpace(currentLocation.X - 1, currentLocation.Y, chessBoard) == 1;
                    bool rightTwo = validSpace(currentLocation.X - 2, currentLocation.Y, chessBoard) == 1;
                    bool rightThree = validSpace(currentLocation.X - 3, currentLocation.Y, chessBoard) == 1;
                    bool rightFour = validSpace(currentLocation.X - 4, currentLocation.Y, chessBoard) == 0;
                    if (rightFour && rightOne && rightThree && rightTwo)
                    {
                        if (chessBoard.Board[(int)currentLocation.X - 4, (int)currentLocation.Y].HasPiece )
                        {
                            if (chessBoard.Board[(int)currentLocation.X - 4, (int)currentLocation.Y].CurrentPiece.GetType().Equals(new Rook().GetType()) && !((Rook)chessBoard.Board[(int)currentLocation.X - 4, (int)currentLocation.Y].CurrentPiece).HasMoved)
                            {
                                possibleMoves.Add(new Vector2(currentLocation.X - 4, currentLocation.Y));
                            }
                        }
                    }
                    if (leftOne && leftThree && leftTwo)
                    {
                        if (chessBoard.Board[(int)currentLocation.X + 3, (int)currentLocation.Y].HasPiece)
                        {
                            if (chessBoard.Board[(int)currentLocation.X + 3, (int)currentLocation.Y].CurrentPiece.GetType().Equals(new Rook().GetType()) && !((Rook)chessBoard.Board[(int)currentLocation.X + 3, (int)currentLocation.Y].CurrentPiece).HasMoved)
                            {
                                possibleMoves.Add(new Vector2(currentLocation.X + 3, currentLocation.Y));
                            }
                        }
                    }
                }
                if (currentLocation.X + 1 <= 7)
                {
                    if ( validSpace( currentLocation.X + 1, currentLocation.Y, chessBoard ) != 0)
                    {
                        possibleMoves.Add(new Vector2(currentLocation.X + 1, currentLocation.Y));
                    }

                    if (currentLocation.Y + 1 <= 7 && validSpace(currentLocation.X + 1, currentLocation.Y + 1, chessBoard) != 0)
                    {
                        possibleMoves.Add(new Vector2(currentLocation.X + 1, currentLocation.Y + 1));
                    }
                    if (currentLocation.Y - 1 >= 0 && validSpace(currentLocation.X + 1, currentLocation.Y - 1, chessBoard) != 0)
                    {
                        possibleMoves.Add(new Vector2(currentLocation.X + 1, currentLocation.Y - 1));
                    }
                }
                if (currentLocation.X - 1 >= 0)
                {
                    if (validSpace(currentLocation.X - 1, currentLocation.Y, chessBoard) != 0)
                    {
                        possibleMoves.Add(new Vector2(currentLocation.X - 1, currentLocation.Y));
                    }
                    if (currentLocation.Y + 1 <= 7 && validSpace(currentLocation.X - 1, currentLocation.Y + 1, chessBoard) != 0)
                    {
                        possibleMoves.Add(new Vector2(currentLocation.X - 1, currentLocation.Y + 1));
                    }
                    if (currentLocation.Y - 1 >= 0 && validSpace(currentLocation.X - 1, currentLocation.Y - 1, chessBoard) != 0)
                    {
                        possibleMoves.Add(new Vector2(currentLocation.X - 1, currentLocation.Y - 1));
                    }
                }
                if (currentLocation.Y + 1 <= 7 && validSpace(currentLocation.X, currentLocation.Y + 1, chessBoard) != 0)
                {
                    possibleMoves.Add(new Vector2(currentLocation.X, currentLocation.Y + 1));
                }
                if (currentLocation.Y - 1 >= 0 && validSpace(currentLocation.X, currentLocation.Y - 1, chessBoard) != 0)
                {
                    possibleMoves.Add(new Vector2(currentLocation.X, currentLocation.Y - 1));
                }

            }
        }

        #endregion
    }
}
