using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessGame.Graphics
{
    class TextButton : Image
    {
        private bool isHovering;

        public bool IsHovering
        {
            get { return isHovering; }
            set
            {
                isHovering = value;
                if (value == true)
                {
                    color = Color.Gray;
                }
                else
                {
                    color = Color.White;
                }
            }
        }

        public TextButton()
        {
            isHovering = false;
            color = Color.White;
        }

        #region Main Methods (Initialize)

        public void Initialize(Vector2 pos)
        {
            this.position = pos;
            this.size = new Vector2(350, 50);
            base.Initialize();
            this.layer = 0.5f;
        }

        public override void LoadGraphicsContent(SpriteBatch spriteBatch, Texture2D texture)
        {
            base.LoadGraphicsContent(spriteBatch, texture);
            this.source = new Rectangle(0, 0, 350, 50);
            this.origin = new Vector2(0, 0);
        }

        #endregion
    }
}
