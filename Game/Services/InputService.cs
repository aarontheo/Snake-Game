using System;
using Raylib_cs;
using Snake_Game.Game.Casting;

namespace Snake_Game.Game
{
    public class InputService
    {
        public Vect GetDirection()
        {
            int dx = 0;
            int dy = 0;
            if(Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                dx -= 1;
            }
            if(Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                dx += 1;
            }
            //re-enable this to allow up and down motion
            if(Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                dy -= 1;
            }
            if(Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                dy += 1;
            }
            return new Vect(dx,dy);
        }
    }
}
