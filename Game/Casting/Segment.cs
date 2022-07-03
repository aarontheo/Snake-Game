using System;
using Snake_Game.Game;

namespace Snake_Game.Game.Casting
{

    public class Segment : Actor
    {
        Actor prev;
        float maxDist;
        public Segment(Actor previous, float maxDist = 20)
        {
            this.prev = previous;
            this.maxDist = maxDist;
        }
        public override void Update(int maxX, int maxY)
        {
            Vect bPos = new Vect(prev.pos.x,prev.pos.y);
            if (pos.x - prev.pos.x > maxX / 2) //wrap check for x axis
            {
                if (pos.x > maxX / 2)
                {
                    bPos.x += maxX;
                }
                else
                {
                    bPos.x -= maxX;
                }
            }
            if (pos.y - prev.pos.y > maxY / 2) //wrap check for y axis
            {

            }
            float dist = pos.Dist(bPos);
            heading = Math.Atan2(pos.y - bPos.y, pos.x - bPos.x);
            pos = pos + new Vect(heading) * (maxDist - dist);
            Wraparound(maxX, maxY);
        }
    }
}
