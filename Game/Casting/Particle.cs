using System;

namespace Snake_Game.Game.Casting
{
    public class Particle: Actor
    {
        public int lifetime;
        public static Random rng = new Random();
        public Particle(int x, int y,string text,int lifetime,int fontSize = 20):base(x,y,text,fontSize)
        {
            this.color = new Raylib_cs.Color(200, 200, 200, 255);
            this.lifetime = lifetime;
            //this.vel = new Vect(rng.Next(-2,1)+rng.NextSingle(),rng.Next(-2,1)+rng.NextSingle());
            this.vel = new Vect(0,-0.02f);
        }

        public override void Update(int maxX,int maxY)
        {
            this.pos += this.vel;
            this.lifetime--;
        }
    }
}
