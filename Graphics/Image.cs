using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ChessGame.Graphics
{
    class Image
    {
        #region Field (spriteBatch, texture, position, source, color, rotation, origin, scale, effects, layer)

        private SpriteBatch spriteBatch;
        private Texture2D texture;
        protected Vector2 position;
        protected Rectangle source;
        protected Color color; //Default White for no tint
        private float rotation;
        protected Vector2 origin;
        private Vector2 scale; // Usually 1 for normal pixel to pixel
        private SpriteEffects effects;
        protected float layer; //Between 0 and 1
        protected Vector2 size;
        protected ContentManager content;

        protected int pieceNumber = 0;

        #endregion

        #region Properties (Position, Rotation, Size, SpriteBatch, Color)

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Vector2 Size
        {
            get { return size; }
            set { size = value; }
        }

        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public float Layer
        {
            get { return layer; }
            set { layer = value; }
        }

        public Rectangle Source
        {
            get { return source; }
            set { source = value; }
        }

        #endregion

        #region Main Methods (LoadGraphicsContent, Initialize, Draw)

        public virtual void LoadGraphicsContent(SpriteBatch spriteBatch, Texture2D texture)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;
        }

        //public virtual void Initialize(ContentManager content)
        public virtual void Initialize()
        {
            //this.content = content;
            if (this.color == null)
            {
                this.color = Color.White;
            }
            this.rotation = 0f;
            this.scale = Vector2.One;
            this.effects = SpriteEffects.None;
            this.layer = 0f;
            this.origin = new Vector2(0);
            
            //TODO: How should these properties be handled? Possibly the size should be set in each sub class
            if (this.size == null)
            {
                this.size = new Vector2(50, 50);
            }

        }

        public virtual void Draw(GameTime gameTime)
        {
            this.spriteBatch.Draw(this.texture, this.position, this.source, this.color, this.rotation, this.origin, this.scale, this.effects, this.layer);
        }

        #endregion

        #region Initialize Methods(CalculateSource)

        protected Rectangle CalculateSource(int index)
        {
            if (index <= 0)
            {
                return new Rectangle(0, 0, (int)this.size.X, (int)this.size.Y);
            }
            else
            {
                int frameRow = index;
                int frameColumn = 1;
                int frameWidth = (int)this.size.X;
                int frameHeight = (int)this.size.Y;
                int totalColumns = this.texture.Width / frameWidth;
                int totalRows = this.texture.Height / frameHeight;

                while (frameRow > totalRows)
                {
                    frameColumn++;
                    frameRow -= totalRows;
                }

                if (index > totalRows * totalColumns)
                {
                    frameColumn = totalColumns;
                    frameRow = totalRows;
                }

                return new Rectangle(
                    (frameColumn - 1) * frameWidth,
                    (frameRow - 1) * frameHeight,
                    frameWidth,
                    frameHeight);
            }
        }

        #endregion
    }
}
