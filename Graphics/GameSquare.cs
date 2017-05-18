using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Graphics
{
    class GameSquare : Image
    {
        #region Member Variables (currentPiece, isSelected, isPossibleMove)

        private Piece currentPiece;
        private bool isSelected;
        private bool isPossibleMove;
        private Color defaultColor;

        #endregion

        #region Properties (CurrentPiece, IsSelected, HasPiece, IsPossibleMove)

        public Piece CurrentPiece
        {
            get { return currentPiece; }
            set { currentPiece = value; }
        }

        public Color DefaultColor
        {
            set 
            {
                color = value;
                defaultColor = value; 
            }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set 
            {
                if (value == true)
                    this.color = Color.Yellow;
                else
                    this.color = defaultColor;
                isSelected = value; 
            }
        }

        public bool HasPiece
        {
            get 
            {
                if (currentPiece == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool IsPossibleMove
        {
            get { return isPossibleMove; }
            set
            {
                if (value == true && OptionsHolder.HighlightMoves)
                    if (defaultColor == Color.Gray)
                    {
                        this.color = Color.DarkCyan;
                    }
                    else
                    {
                        this.color = Color.Cyan;
                    }

                else
                    this.color = defaultColor;
                isPossibleMove = value;
            }
        }

        #endregion

        public GameSquare(Piece piece)
        {
            if (piece != null)
            {
                currentPiece = piece;
            }
            else //Square does not have a piece on it
            {
                currentPiece = null;
            }
            isSelected = false;
        }
        
        #region Main Methods (Initialize, LoadGraphicsContent, Draw)

        //public virtual void Initialize(Vector2 pos, ContentManager content)
        public virtual void Initialize(Vector2 pos)
        {
            this.position = pos;
            this.source = new Rectangle(0, 0, 50, 50);
            base.Initialize();
        }

        public override void LoadGraphicsContent(SpriteBatch spriteBatch, Texture2D texture)
        {
            base.LoadGraphicsContent(spriteBatch, texture);
            this.source = new Rectangle(0, 0, 50, 50);
            this.origin = new Vector2(0, 0);//source.Width / 2, source.Height / 2);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        #endregion
    }
}
