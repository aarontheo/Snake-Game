using System;

namespace Snake_Game.Game.Casting
{
    /// <summary>
    /// A Point is essentially a Vect that deals in ints rather than floats.
    /// </summary>
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point operator +(Point a,Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }
        public static Point operator +(Point a,Vect b)
        {
            return new Point(a.x+((int)Math.Round(b.x)),a.y+((int)Math.Round(b.y)));
        }
        public static Point operator *(Point a, int b)
        {
            return new Point(a.x * b, a.y * b);
        }
        public static Vect operator *(Point a, float b)
        {
            return new Vect(a.x * b, a.y * b);
        }
        public Vect toVect()
        {
            return new Vect(x, y);
        }
    }
}
