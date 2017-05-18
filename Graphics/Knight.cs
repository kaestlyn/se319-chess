using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ChessGame.Graphics
{
    class Knight : Piece
    {
        public Knight()
        {

        }

        #region Main Methods (Initialize, LoadGraphicsContent, Draw, Update)

        public override void Initialize(Vector2 pos)
        {
            this.pieceNumber = 2;
            base.Initialize(pos);
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

        public override void CalculateMoves(ChessGame.Objects.ChessBoard chessBoard)
        {
            possibleMoves = new List<Vector2>();
            if (isDead)
            {
                possibleMoves = null;
            }
            else
            {

                if (currentLocation.X - 2 >= 0)
                {
                    if (currentLocation.Y - 1 >= 0)
                    {
                        if (validSpace(currentLocation.X - 2, currentLocation.Y - 1, chessBoard) != 0)
                        {
                            possibleMoves.Add(new Vector2(currentLocation.X - 2, currentLocation.Y - 1));
                        }
                    }
                    if (currentLocation.Y + 1 <= 7)
                    {
                        if (validSpace(currentLocation.X - 2, currentLocation.Y + 1, chessBoard) != 0)
                        {
                            possibleMoves.Add(new Vector2(currentLocation.X - 2, currentLocation.Y + 1));
                        }
                    }
                }
                if (currentLocation.X - 1 >= 0)
                {
                    if (currentLocation.Y - 2 >= 0)
                    {
                        if (validSpace(currentLocation.X - 1, currentLocation.Y - 2, chessBoard) != 0)
                        {
                            possibleMoves.Add(new Vector2(currentLocation.X - 1, currentLocation.Y - 2));
                        }
                    }
                    if (currentLocation.Y + 2 <= 7)
                    {
                        if (validSpace(currentLocation.X - 1, currentLocation.Y + 2, chessBoard) != 0)
                        {
                            possibleMoves.Add(new Vector2(currentLocation.X - 1, currentLocation.Y + 2));
                        }
                    }
                }
                if (currentLocation.X + 2 <= 7)
                {
                    if (currentLocation.Y - 1 >= 0)
                    {
                        if (validSpace(currentLocation.X + 2, currentLocation.Y - 1, chessBoard) != 0)
                        {
                            possibleMoves.Add(new Vector2(currentLocation.X + 2, currentLocation.Y - 1));
                        }
                    }
                    if (currentLocation.Y + 1 <= 7)
                    {
                        if (validSpace(currentLocation.X + 2, currentLocation.Y + 1, chessBoard) != 0)
                        {
                            possibleMoves.Add(new Vector2(currentLocation.X + 2, currentLocation.Y + 1));
                        }
                    }
                }
                if (currentLocation.X + 1 <= 7)
                {
                    if (currentLocation.Y - 2 >= 0)
                    {
                        if (validSpace(currentLocation.X + 1, currentLocation.Y - 2, chessBoard) != 0)
                        {
                            possibleMoves.Add(new Vector2(currentLocation.X + 1, currentLocation.Y - 2));
                        }
                    }
                    if (currentLocation.Y + 2 <= 7)
                    {
                        if (validSpace(currentLocation.X + 1, currentLocation.Y + 2, chessBoard) != 0)
                        {
                            possibleMoves.Add(new Vector2(currentLocation.X + 1, currentLocation.Y + 2));
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
            }
            return retValue;
        }

        #endregion
    }
}
