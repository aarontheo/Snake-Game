using System;
using Raylib_cs;
using Snake_Game.Game;


//TODO: Maybe change the pos Vect back to a point?
namespace Snake_Game.Game.Casting
{
    public class Actor
    {
        public Vect pos;
        public int fontSize { get; set; }
        public Vect vel = new Vect(0,0);
        public string text { get; set; }
        public Color color;
        public Actor(int x = 0, int y = 0,string text = "@",int fontSize = 30)
        {
            pos = new Vect(x, y);
            this.text = text;
            this.fontSize = fontSize;
            this.color = new Color(200,200,200,255);
        }
        public void Draw()
        {
            //Raylib.DrawRectangleLinesEx(getBound(),2,Color.GOLD);
            Raylib.DrawText(text,((int)pos.x),((int)pos.y),fontSize,color);
        }
        public void Draw(bool debug)
        {
            Raylib.DrawRectangleLinesEx(getBound(),2,Color.GOLD);
            Raylib.DrawText(text,((int)pos.x),((int)pos.y),fontSize,color);
        }
        public virtual void Update(int maxX, int maxY)
        {
            pos = pos + vel;
        }
        public Rectangle getBound()
        {
            var size = Raylib.MeasureTextEx(Raylib.GetFontDefault(), text, fontSize, 0);
            //return new Rectangle(pos.x, pos.y, fontSize, fontSize);
            return new Rectangle(pos.x, pos.y+size.Y/3, size.X, size.Y/2);
        }
        public bool isColliding(Actor b)
        {
            return Raylib.CheckCollisionRecs(this.getBound(), b.getBound());
        }
    }
}
