using System.Collections;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ChessGame.Objects;


namespace ChessGame.Graphics
{
    class Rook : Piece
    {
        private bool firstMove;

        public bool HasMoved
        {
            get { return !firstMove; }
        }
       
        public Rook()
        {
            firstMove = true;
        }

        #region Main Methods (Initialize, CalculateMoves, LoadGraphicsContent, Draw, Update)

        public override void Initialize(Vector2 pos)
        {
            this.pieceNumber = 5;
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
                //Calculate moves here
                possibleMoves = new List<Vector2>();
                
                int x = (int)currentLocation.X;
                int y = (int)currentLocation.Y;

                while (y < 8)
                {
                    y++;
                    if (validSpace(x, y, chessBoard) == 1)
                    {
                        possibleMoves.Add(new Vector2(x, y));
                    }
                    else if (validSpace(x, y, chessBoard) == 2)
                    {
                        possibleMoves.Add(new Vector2(x, y));
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                y = (int)currentLocation.Y;
                while (y > -1)
                {
                    y--;
                    if (validSpace(x, y, chessBoard) == 1)
                    {
                        possibleMoves.Add(new Vector2(x, y));
                    }
                    else if (validSpace(x, y, chessBoard) == 2)
                    {
                        possibleMoves.Add(new Vector2(x, y));
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                y = (int)currentLocation.Y;
                while (x < 8)
                {
                    x++;
                    if (validSpace(x, y, chessBoard) == 1)
                    {
                        possibleMoves.Add(new Vector2(x, y));
                    }
                    else if (validSpace(x, y, chessBoard) == 2)
                    {
                        possibleMoves.Add(new Vector2(x, y));
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                x = (int)currentLocation.X;
                while (x > -1)
                {
                    x--;
                    if (validSpace(x, y, chessBoard) == 1)
                    {
                        possibleMoves.Add(new Vector2(x, y));
                    }
                    else if (validSpace(x, y, chessBoard) == 2)
                    {
                        possibleMoves.Add(new Vector2(x, y));
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                if (firstMove)
                {
                    bool leftOne = validSpace(currentLocation.X + 1, currentLocation.Y, chessBoard) == 1;
                    bool leftTwo = validSpace(currentLocation.X + 2, currentLocation.Y, chessBoard) == 1;
                    bool leftThree = validSpace(currentLocation.X + 3, currentLocation.Y, chessBoard) == 1;
                    bool leftFour = validSpace(currentLocation.X + 4, currentLocation.Y, chessBoard) == 0;
                    bool rightOne = validSpace(currentLocation.X - 1, currentLocation.Y, chessBoard) == 1;
                    bool rightTwo = validSpace(currentLocation.X - 2, currentLocation.Y, chessBoard) == 1;
                    bool rightThree = validSpace(currentLocation.X - 3, currentLocation.Y, chessBoard) == 0;
                    if (rightOne && rightThree && rightTwo && currentLocation.X == 7 )
                    {
                        if (chessBoard.Board[(int)currentLocation.X - 3, (int)currentLocation.Y].HasPiece)
                        {
                            if (chessBoard.Board[(int)currentLocation.X - 3, (int)currentLocation.Y].CurrentPiece.GetType().Equals(new King().GetType()) && !((King)chessBoard.Board[(int)currentLocation.X - 3, (int)currentLocation.Y].CurrentPiece).HasMoved)
                            {
                                possibleMoves.Add(new Vector2(currentLocation.X - 3, currentLocation.Y));
                            }
                        }
                    }
                    if (leftFour && leftOne && leftThree && leftTwo && currentLocation.X  == 0)
                    {
                        if (chessBoard.Board[(int)currentLocation.X + 4, (int)currentLocation.Y].HasPiece)
                        {
                            if (chessBoard.Board[(int)currentLocation.X + 4, (int)currentLocation.Y].CurrentPiece.GetType().Equals(new King().GetType()) && !((King)chessBoard.Board[(int)currentLocation.X + 4, (int)currentLocation.Y].CurrentPiece).HasMoved)
                            {
                                possibleMoves.Add(new Vector2(currentLocation.X + 4, currentLocation.Y));
                            }
                        }
                    }
                }
            }
        }


        public override List<Vector2> CaptureLine(Vector2 location)
        {
            List<Vector2> retValue = new List<Vector2>();
            if (this.possibleMoves.Contains(location))
            {
                retValue.Add(this.currentLocation);

                // Horizontal Capture
                if (location.X == this.currentLocation.X)
                {
                    if(location.X < this.currentLocation.X)
                    {
                        foreach(Vector2 vec in this.possibleMoves)
                        {
                            if (vec.X < currentLocation.X)
                            {
                                retValue.Add(vec);
                             }
                        }
                    }
                    else if (location.X > this.currentLocation.X)
                    {
                        foreach (Vector2 vec in this.possibleMoves)
                        {
                            if (vec.X > currentLocation.X)
                            {
                                retValue.Add(vec);
                            }
                        }
                    }
                }
                // Vertical Capture
                if (location.Y == this.currentLocation.Y)
                {
                    if (location.Y < this.currentLocation.Y)
                    {
                        foreach (Vector2 vec in this.possibleMoves)
                        {
                            if (vec.Y < currentLocation.Y)
                            {
                                retValue.Add(vec);
                            }
                        }
                    }
                    else if (location.Y > this.currentLocation.Y)
                    {
                        foreach (Vector2 vec in this.possibleMoves)
                        {
                            if (vec.Y > currentLocation.Y)
                            {
                                retValue.Add(vec);
                            }
                        }
                    }
                }
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
