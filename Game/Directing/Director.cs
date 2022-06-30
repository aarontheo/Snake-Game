using System;
using Raylib_cs;
using Snake_Game.Game;
using Snake_Game.Game.Casting;

namespace Snake_Game.Directing.Game
{
    public class Director
    {
        private VideoService videoService;
        private bool isRunning = false;
        public Director(VideoService videoService)
        {
            this.videoService = videoService;
            //this.inputService = inputService;
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
                    cast.Draw();
                }
            }
        }
    }
}