using System;

namespace Snake_Game.Game.Casting
{
    public class Collectible : Actor
    {
        public int pointValue;
        public static Random rng = new Random();
        public static int dark = 80;
        public Collectible(int x, int y, int pointValue) : base(x, y)
        {
            this.pointValue = pointValue;
            byte r = (byte)rng.Next(127, 255);
            byte g = (byte)rng.Next(127, 255);
            byte b = (byte)rng.Next(127, 255);
            if (pointValue > 0)
            {
                this.text = "$";
                this.color = new Raylib_cs.Color(r, g, b, (byte)255);
            }
            else
            {
                this.text = "*";
                this.color = new Raylib_cs.Color(r-dark, r-dark, r-dark, (byte)255);
            }
            // this.vel.y = Math.Abs((float)pointValue / 20);
            this.vel.y = 0.05f * Math.Abs((float)pointValue/4);
        }
    }
}
