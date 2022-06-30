using System;
using Snake_Game.Game;

namespace Snake_Game.Game.Casting
{
    public class Snake : Actor
    {
        public Snake(int x, int y,string text,int fontSize=30):base(x,y,text)
        {

        }
        InputService inputS = new InputService();
        float speedLimit = 0.5f;
        float decel = 0.96f; //between 0 and 1, higher values are more floaty
        float accel = 0.01f;
        public override void Update(int maxX, int maxY)
        {
            vel += inputS.GetDirection() * accel; //change velocity based on input
            vel = vel.Clamp(speedLimit);
            base.Update(maxX, maxY);
            vel *= decel;
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
