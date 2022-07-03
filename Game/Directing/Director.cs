using System;
using Raylib_cs;
using Snake_Game.Services;
using Snake_Game.Game.Casting;

namespace Snake_Game.Directing
{
    public class Director
    {
        private VideoService videoService;
        private bool isRunning = false;
        public Director(VideoService videoService)
        {
            this.videoService = videoService;
        }
        public void StartGame(Cast cast)
        {
            isRunning = true;
            videoService.OpenWindow();
            while (!Raylib.WindowShouldClose())
            {
                if (isRunning)
                {
                    cast.Update(videoService.width, videoService.height);
                    
                    videoService.ClearBuffer();
                    cast.Draw();
                    videoService.FlushBuffer();
                }
            }
            videoService.CloseWindow();
        }
    }
}