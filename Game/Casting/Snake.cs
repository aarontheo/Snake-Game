using System;
using Snake_Game.Game;
using Raylib_cs;

namespace Snake_Game.Game.Casting
{
    public class Snake : Actor
    {
        InputService inputS = new InputService(KeyboardKey.KEY_LEFT, KeyboardKey.KEY_RIGHT);
        float speed = 0.5f;
        float turnSpeed = 0.08f;
        Rectangle bound;
        public Snake(int x, int y, int width, int height, int initialSize, int fontSize = 30) : base(x, y)
        {
            bound = new Rectangle(x, y, width, height);
        }
        public override void Update(int maxX, int maxY)
        {
            heading += inputS.GetLR() * turnSpeed;
            vel += new Vect(heading);
            base.Update(maxX, maxY);
            //this bit allows for screen wraparound
            if (pos.x > maxX || pos.x < 0 - fontSize)
            {
                if (pos.x < 0 - fontSize)
                {
                    pos.x = maxX;
                }
                else
                {
                    pos.x = 0 - fontSize;
                }
            }
            if (pos.y > maxY || pos.y < 0 - fontSize)
            {
                if (pos.y < 0 - fontSize)
                {
                    pos.y = maxY;
                }
                else
                {
                    pos.y = 0 - fontSize;
                }
            }
        }
    }
}