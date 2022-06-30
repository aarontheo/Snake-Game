using System;
using Raylib_cs;
using Snake_Game.Game;


//TODO: Maybe change the pos Vect back to a point?
namespace Snake_Game.Game.Casting
{
    public class Actor : IActor
    {
        public Color color = Color.GREEN;
        public double heading = 0;
        public Point size;
        public Vect pos;
        public Vect vel = new Vect(0, 0);
        public Actor(int x = 0, int y = 0, int width = 10, int height = 10)
        {
            pos = new Vect(x, y);
            size = new Point(width, height);
        }
        public virtual void Draw()
        {
            Raylib.DrawRectangle((int)pos.x, (int)pos.y, size.x, size.y, color);
        }
        public virtual void Update(int maxX, int maxY)
        {
            pos = pos + vel;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        /// <param name="wraparound">Ok so this parameter isn't used in </param>
        public void Wraparound(int maxX,int maxY)
        {
            //this bit allows for screen wraparound
            if (pos.x < 0 - size.x)
            {
                pos.x = maxX;
            }
            else if (pos.x > maxX)
            {
                pos.x = 0 - size.x;
            }
            if (pos.y < 0 - size.y)
            {
                pos.y = maxY;
            }
            else if (pos.y > maxY)
            {
                pos.y = 0 - size.y;
            }
        }
        public virtual Rectangle getBound()
        {
            //return new Rectangle(pos.x, pos.y, fontSize, fontSize);
            return new Rectangle(pos.x, pos.y, size.x, size.y);
        }
        public bool isColliding(IActor b)
        {
            return Raylib.CheckCollisionRecs(this.getBound(), b.getBound());
        }
    }
}
