﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Points
{
    public class Point
    {
        public int Id;
        public int x;
        public int y;
        public int VectorX;
        public int VectorY;
        public int Width;
        public int BumpCount;
        public int TimeLife;
        public int Weight;
        public Color Color;
        Random rnd = new Random();

        public Point(int x, int y)
        {
            this.Width = rnd.Next(5, 15);
            this.Weight = Width * Width / 7;
            this.VectorX = rnd.Next(-10, 10)-Weight;
            this.VectorY = rnd.Next(-10, 10)-Weight;
            this.x = x;
            this.y = y;
            this.BumpCount = 0;
            this.TimeLife = 0;
            _AddColor();
        }
        private void _AddColor()
        {
            switch (rnd.Next(1, 7))
            {
                case 1: { this.Color = Color.Red; break; }
                case 2: { this.Color = Color.Orange; break; }
                case 3: { this.Color = Color.Yellow; break; }
                case 4: { this.Color = Color.LightBlue; break; }
                case 5: { this.Color = Color.Blue; break; }
                case 6: { this.Color = Color.Green; break; }
                case 7: { this.Color = Color.Violet; break; }
                default: break;
            }
        }

        public void Way(int width, int height, int locX, int locY)
        {
            if ((this.x + this.VectorX) >= width)
            {
                this.x = width;
                this.VectorX = -this.VectorX;
                this.BumpCount++;
            }

            if ((this.y + this.VectorY) >= height)
            {
                this.y = height;
                this.VectorY = -this.VectorY;
                this.BumpCount++;
            }

            if ((this.x + this.VectorX) < locX)
            {
                this.x = locX;
                this.VectorX = -this.VectorX;
                this.BumpCount++;
            }

            if ((this.y + this.VectorY) < locY)
            {
                this.y = locY;
                this.VectorY = -this.VectorY;
                this.BumpCount++;
            }

            this.x += this.VectorX;
            this.y += this.VectorY;
        }

    }
}