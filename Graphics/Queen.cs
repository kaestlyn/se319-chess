using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ChessGame.Objects;
using System.Collections.Generic;

namespace ChessGame.Graphics
{
    class Queen : Piece
    {
        public Queen()
        {

        }

        #region Main Methods (Initialize, LoadGraphicsContent, Draw, Update)

        public override void Initialize(Vector2 pos)
        {
            this.pieceNumber = 6;
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

                // Down to the Left
                x = (int)currentLocation.X - 1;
                y = (int)currentLocation.Y - 1;
                while (x != -1 && y != -1)
                {
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
                    x--;
                    y--;
                }

                // Up to the left
                x = (int)currentLocation.X - 1;
                y = (int)currentLocation.Y + 1;
                while (x != -1 && y != 8)
                {
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
                    x--;
                    y++;
                }

                // Down to the Right
                x = (int)currentLocation.X + 1;
                y = (int)currentLocation.Y - 1;
                while (x != 8 && y != -1)
                {
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
                    x++;
                    y--;
                }

                // Up to the Right
                x = (int)currentLocation.X + 1;
                y = (int)currentLocation.Y + 1;
                while (x != 8 && y != 8)
                {
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
                    x++;
                    y++;
                }
                // TODO: remove moves that are invalid - pieces in the way
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
                    if (location.X < this.currentLocation.X)
                    {
                        foreach (Vector2 vec in this.possibleMoves)
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
                else if (location.Y == this.currentLocation.Y)
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
                else if (this.currentLocation.X < location.X && this.currentLocation.Y < location.Y)
                {
                    foreach (Vector2 vec in this.possibleMoves)
                    {
                        if (vec.X > this.currentLocation.X && vec.Y > this.currentLocation.Y)
                        {
                            retValue.Add(vec);
                        }
                    }
                }
                else if (this.currentLocation.X < location.X && this.currentLocation.Y > location.Y)
                {
                    foreach (Vector2 vec in this.possibleMoves)
                    {
                        if (vec.X > this.currentLocation.X && vec.Y < this.currentLocation.Y)
                        {
                            retValue.Add(vec);
                        }
                    }
                }
                else if (this.currentLocation.X > location.X && this.currentLocation.Y < location.Y)
                {
                    foreach (Vector2 vec in this.possibleMoves)
                    {
                        if (vec.X < this.currentLocation.X && vec.Y > this.currentLocation.Y)
                        {
                            retValue.Add(vec);
                        }
                    }
                }
                else if (this.currentLocation.X > location.X && this.currentLocation.Y > location.Y)
                {
                    foreach (Vector2 vec in this.possibleMoves)
                    {
                        if (vec.X < this.currentLocation.X && vec.Y < this.currentLocation.Y)
                        {
                            retValue.Add(vec);
                        }
                    }
                }
            }
            return retValue;
        }

        #endregion
    }
}
