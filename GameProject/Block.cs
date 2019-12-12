using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class Block
    {
        private Texture2D _texture;
        public Vector2 Position;
        public Rectangle CollisionRectangle;

        public Block(Texture2D texture)
        {
            _texture = texture;
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
        }

        public void Update(GameTime gameTime)
        {
            CollisionRectangle.X = (int)Position.X;
            CollisionRectangle.Y = (int)Position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture,Position,Color.White);
        }
    }
}
