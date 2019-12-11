using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _GameProject
{
    class Player
    {
        private Texture2D RunLeft, RunRight,IdleLeft, IdleRight, currentTexture;
        private Vector2 position, movement;
        Animation animationLeft, animationRight, animationIdleLeft, AnimationIdleRight;
        Animation currentAnimation;
        Remote remote;
        public Rectangle CollisionRectangle;

        public Player(Vector2 _position, Texture2D _textureRL,Texture2D _textureRR, Texture2D _textureIL, Texture2D _textureIR, Remote keyBoard)
        {
            Init(_position, keyBoard);
            RunRight = _textureRR;
            RunLeft = _textureRL;
            IdleLeft = _textureIL;
            IdleRight = _textureIR;
            currentTexture = IdleRight;

            remote = keyBoard;

            CreateAnimationLeftRight();
        }

        private void Init(Vector2 _position, Remote keyBoard)
        {
            position = _position;
            remote = keyBoard;
            CollisionRectangle = new Rectangle((int)position.X, (int)position.Y, 23, 34);
        }


        private void CreateAnimationLeftRight()
        {
            animationLeft = new Animation();
            animationLeft.AddFrame(new Rectangle(0, 0, 23, 34));
            animationLeft.AddFrame(new Rectangle(23, 0, 23, 34));
            animationLeft.AddFrame(new Rectangle(46, 0, 23, 34));
            animationLeft.AddFrame(new Rectangle(69, 0, 23, 34));
            animationLeft.AddFrame(new Rectangle(92, 0, 23, 34));
            animationLeft.AddFrame(new Rectangle(115, 0, 23, 34));
            animationLeft.AddFrame(new Rectangle(138, 0, 23, 34));
            animationLeft.AddFrame(new Rectangle(161, 0, 23, 34));

            animationRight = new Animation();
            animationRight.AddFrame(new Rectangle(0, 0, 23, 34));
            animationRight.AddFrame(new Rectangle(23, 0, 23, 34));
            animationRight.AddFrame(new Rectangle(46, 0, 23, 34));
            animationRight.AddFrame(new Rectangle(69, 0, 23, 34));
            animationRight.AddFrame(new Rectangle(92, 0, 23, 34));
            animationRight.AddFrame(new Rectangle(115, 0, 23, 34));
            animationRight.AddFrame(new Rectangle(138, 0, 23, 34));
            animationRight.AddFrame(new Rectangle(161, 0, 23, 34));

            animationIdleLeft = new Animation();
            animationIdleLeft.AddFrame(new Rectangle(0, 0, 21, 35));
            animationIdleLeft.AddFrame(new Rectangle(21, 0, 21, 35));
            animationIdleLeft.AddFrame(new Rectangle(42, 0, 21, 35));
            animationIdleLeft.AddFrame(new Rectangle(63, 0, 21, 35));
            animationIdleLeft.AddFrame(new Rectangle(84, 0, 21, 35));
            animationIdleLeft.AddFrame(new Rectangle(105, 0, 21, 35));
            animationIdleLeft.AddFrame(new Rectangle(126, 0, 21, 35));
            animationIdleLeft.AddFrame(new Rectangle(147, 0, 21, 35));
            animationIdleLeft.AddFrame(new Rectangle(168, 0, 21, 35));
            animationIdleLeft.AddFrame(new Rectangle(189, 0, 21, 35));
            animationIdleLeft.AddFrame(new Rectangle(210, 0, 21, 35));
            animationIdleLeft.AddFrame(new Rectangle(234, 0, 21, 35));

            AnimationIdleRight = new Animation();
            AnimationIdleRight.AddFrame(new Rectangle(0, 0, 21, 35));
            AnimationIdleRight.AddFrame(new Rectangle(21, 0, 21, 35));
            AnimationIdleRight.AddFrame(new Rectangle(42, 0, 21, 35));
            AnimationIdleRight.AddFrame(new Rectangle(63, 0, 21, 35));
            AnimationIdleRight.AddFrame(new Rectangle(84, 0, 21, 35));
            AnimationIdleRight.AddFrame(new Rectangle(105, 0, 21, 35));
            AnimationIdleRight.AddFrame(new Rectangle(126, 0, 21, 35));
            AnimationIdleRight.AddFrame(new Rectangle(147, 0, 21, 35));
            AnimationIdleRight.AddFrame(new Rectangle(168, 0, 21, 35));
            AnimationIdleRight.AddFrame(new Rectangle(189, 0, 21, 35));
            AnimationIdleRight.AddFrame(new Rectangle(210, 0, 21, 35));
            AnimationIdleRight.AddFrame(new Rectangle(234, 0, 21, 35));

            currentAnimation = AnimationIdleRight;
        }

        double xOffset = 0;
        public void Update(GameTime gameTime)
        {
            
            remote.Update();

            if (remote.left)
            {
                position = Vector2.Add(position, new Vector2(-2, 0));
                currentAnimation = animationLeft;
                currentTexture = RunLeft;
            }

            if (remote.right)
            {
                position = Vector2.Add(position, new Vector2(2, 0));
                currentTexture = RunRight;
                currentAnimation = animationRight;
            }

            if (!remote.right && !remote.left)
            {
                if (currentAnimation == animationLeft)
                {
                    currentAnimation = animationIdleLeft;
                    currentTexture = IdleLeft;
                }
                else if (currentAnimation == animationRight)
                {
                    currentTexture = IdleRight;
                    currentAnimation = AnimationIdleRight;
                }
            }
            CollisionRectangle.X = (int)position.X;
            CollisionRectangle.Y = (int)position.Y;
            currentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
           // spriteBatch.Draw(currentTexture, position,currentAnimation.currentFrame.SourceRectangle, Color.White);

            spriteBatch.Draw(currentTexture, position, currentAnimation.currentFrame.SourceRectangle, Color.AliceBlue, 0f, new Vector2(0, 0),1, SpriteEffects.FlipHorizontally, 1);


        }
    }
}
