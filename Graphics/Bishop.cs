using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ChessGame.Objects;
using System.Collections.Generic;

namespace ChessGame.Graphics
{
    class Bishop : Piece
    {
        public Bishop()
        {

        }

        #region Main Methods (Initialize, CalculateMoves, LoadGraphicsContent, Draw, Update)

        public override void Initialize(Vector2 pos)
        {
            this.pieceNumber = 3;
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
                int x, y;

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
                if (this.currentLocation.X < location.X && this.currentLocation.Y < location.Y)
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

        //public void LoadGraphicsContent(SpriteBatch spriteBatch, Texture2D texture)
        //{

        //}

        //public void Draw()
        //{

        //}

        //public void Update()
        //{

        //}

        #endregion
    }
}
