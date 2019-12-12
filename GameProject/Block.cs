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
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 158, 31);
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture,Position,Color.White);
        }
    }
}
