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
        public Snake(int x, int y, int width, int height, int initialSize,Color color) : base(x, y)
        {
            this.color = color;
        }
        public override void Update(int maxX, int maxY)
        {
            heading += inputS.GetLR() * turnSpeed;
            vel += new Vect(heading);
            base.Update(maxX, maxY);
            Wraparound(maxX, maxY);
        }
    }
}