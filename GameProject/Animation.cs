﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class Animation
    {
        private List<AnimationFrame> frames;
        public AnimationFrame currentFrame;
        private double xOffset;
        int counter = 0;

        public Animation()
        {
            frames = new List<AnimationFrame>();
            xOffset = 0;
        }

        public void AddFrame(Rectangle rectangle)
        {
            AnimationFrame frame = new AnimationFrame()
            {
                SourceRectangle = rectangle
            };

            frames.Add(frame);
            currentFrame = frames[0];
        }

        public void Update(GameTime gameTime)
        {
            xOffset += currentFrame.SourceRectangle.Width * gameTime.ElapsedGameTime.Milliseconds / 1000;
            if (xOffset >= currentFrame.SourceRectangle.Width)
            {
                counter++;
                if (counter >= frames.Count)
                    counter = 0;

                currentFrame = frames[counter];
                xOffset = 0;
            }
        }
    }
}
