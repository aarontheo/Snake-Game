using System;
using Snake_Game.Game;
using Raylib_cs;

namespace Snake_Game.Game.Casting
{
    public class Snake : Actor
    {
        InputService inputS = new InputService(KeyboardKey.KEY_LEFT, KeyboardKey.KEY_RIGHT);
        float speed = 0.5f;
        float maxSpeed = 3f;
        float turnSpeed = 0.08f;
        List<Segment> segments;
        public Snake(int x, int y, int width, int height, int initialSize,Color color) : base(x, y)
        {
            this.color = color;
            segments = new List<Segment>(initialSize);

            segments.Add(new Segment(this)); //the first segment is linked to the snake's head
            for (int i = 1; i < initialSize; i++)
            {
                Grow();
            }
        }
        public void Grow()
        {
            segments.Add(new Segment(segments.Last()));
        }
        public override void Update(int maxX, int maxY)
        {
            //heading += inputS.GetLR() * turnSpeed;
            //pos += new Vect(heading)*speed;
            vel += inputS.GetDirection() * speed;
            vel = vel.Clamp(maxSpeed);
            base.Update(maxX, maxY);
            Wraparound(maxX, maxY);
            foreach(Segment s in segments)
            {
                s.Update(maxX, maxY);
            }
        }
        public override void Draw()
        {
            base.Draw();
            foreach (Segment s in segments)
            {
                s.Draw();
            }
        }
        // public bool isColliding(Snake b)
        // {

        // }
    }
}