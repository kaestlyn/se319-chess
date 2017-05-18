using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using ChessGame.Objects;

namespace ChessGame.Graphics
{
    class Piece : Image
    {
        #region Member Variables (playerIndex, isDead)

        protected int playerIndex;
        protected bool isDead;
        protected Vector2 currentLocation;
        protected List<Vector2> possibleMoves;

        #endregion

        #region Properties (PlayerIndex, IsDead, CurrentLocation, PossibleMoves)

        public int PlayerIndex
        {
            get { return playerIndex; }
            set { playerIndex = value; }
        }

        public bool IsDead
        {
            get { return isDead; }
            set 
            { 
                isDead = value;
                if (value == true)
                {
                    this.currentLocation = new Vector2(-1, -1);
                }
            }
        }

        public Vector2 CurrentLocation
        {
            get { return currentLocation; }
            set
            {
                currentLocation = value;
                this.position = new Vector2((currentLocation.X * 50) + 200, (currentLocation.Y * 50) + 100);
            }
        }

        public List<Vector2> PossibleMoves
        {
            get { return possibleMoves; }
        }

        #endregion

        public Piece()
        {
            isDead = false;
        }

        #region Main Methods (Initialize, LoadGraphicsContent, Update, Draw, GetMoves, )

        //public void Initialize(ContentManager content)
        public virtual void Initialize(Vector2 pos)
        {
            this.position = pos;
            this.size = new Microsoft.Xna.Framework.Vector2(50, 50);
            base.Initialize();
            UpdateColors();
            this.layer = 0.5f;
        }

        public override void LoadGraphicsContent(SpriteBatch spriteBatch, Texture2D texture)
        {
            base.LoadGraphicsContent(spriteBatch, texture);
            this.source = CalculateSource(pieceNumber);
            this.origin = new Vector2(0, 0);//source.Width / 2, source.Height / 2);
        }

        public virtual void CalculateMoves(ChessBoard chessBoard)
        {

        }

        public virtual List<Vector2> CaptureLine(Vector2 location)
        {
            return new List<Vector2>();
        }


        public int validSpace(float x, float y, ChessBoard chessBoard)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                return 0;
            }
            if (!chessBoard.Board[(int)x, (int)y].HasPiece)
            {
                return 1;
            }
            else
            {
                if (chessBoard.Board[(int)x, (int)y].CurrentPiece.PlayerIndex == PlayerIndex)
                {
                    return 0;
                }
                else
                {
                    return 2;
                }
            }
        }//Return 1 if the space is movable, 0 if its not, 2 if enemy piece is present

        public void UpdateColors()
        {
            if (playerIndex == 1)
            {
                this.color = OptionsHolder.Player1Color; //Color.White;
            }
            else
            {
                this.color = OptionsHolder.Player2Color; //Color.Gray;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (isDead == false)
            {
                base.Draw(gameTime);
            }
        }

        #endregion

        public virtual void AfterMove()
        {

        }
    }
}