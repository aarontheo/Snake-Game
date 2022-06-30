using System;
using Raylib_cs;

namespace Snake_Game.Game
{
    public class VideoService
    {
        private int framerate = 0;
        public int width { get; }
        public int height { get; }
        private string title;
        public Color BGColor { get; set; }
        public VideoService(int width,int height,Color BGColor,string title,int framerate = 60)
        {
            this.width = width;
            this.height = height;
            this.BGColor = BGColor;
            this.title = title;
        }
        public void OpenWindow()
        {
            Raylib.InitWindow(width, height, title);
        }
        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }
        public void ClearBuffer()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(BGColor);
        }
        public void FlushBuffer()
        {
            Raylib.EndDrawing();
        }
    }
}
