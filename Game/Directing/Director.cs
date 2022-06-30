using System;
using Raylib_cs;
using Snake_Game.Game;
using Snake_Game.Game.Casting;

namespace Snake_Game.Directing.Game
{
    public class Director
    {
        private VideoService videoService;
        private Random rng = new Random(1337); //leet hackr skillz
        //private InputService inputService;
        private int score = 0;
        private int spawnCounter = 0;
        private int spawnInterval = 1500;
        private int maxVal = 4;
        private int minVal = 2;
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
                    Update(cast);
                    if (score < 0)
                    {
                        isRunning = false;
                        cast.Add("gameover", new Actor(videoService.width / 2 - 100, videoService.height / 2, "GAME OVER",40));
                    }
                }
                videoService.ClearBuffer();
                Draw(cast);
                videoService.FlushBuffer();
            }
            videoService.CloseWindow();
            Console.WriteLine("Program Ended!");
        }
        // public void GetInputs(Cast cast)
        // {
        //     Actor player = cast.GetFirstActor("player");
        //     Point dir = inputService.GetDirection();
        //     player.vel += dir;
        // }
        public void Update(Cast cast)
        {
            //randomly spawn gems/rocks
            if (spawnCounter >= spawnInterval)
            {
                spawnCounter = 0;
                int value = rng.Next(minVal, maxVal);
                int x = rng.Next(videoService.width);
                cast.Add("collectibles", new Collectible(x-(x%30), -30, value));
                value = rng.Next(-maxVal, -minVal);
                x = rng.Next(videoService.width);
                cast.Add("collectibles", new Collectible(x-(x%30), -30, value));
            }
            var player = cast.GetFirstActor("players");
            foreach (Collectible thing in cast.GetActors("collectibles"))
            {
                if (player.isColliding(thing))
                {
                    score += thing.pointValue;
                    cast.Add("particles", new Particle((int)thing.pos.x, (int)thing.pos.y, $"${thing.pointValue}",2000));
                    cast.Remove("collectibles", thing);
                }
                if (thing.pos.y > videoService.height)
                {
                    cast.Remove("collectibles", thing);
                }
            }
            foreach (Particle p in cast.GetActors("particles"))
            {
                if (p.lifetime <= 0)
                {
                    cast.Remove("particles", p);
                }
            }
            cast.GetFirstActor("banners").text = $"Points: {score}";
            cast.Update(videoService.width,videoService.height);
            spawnCounter++;
        }
        public void Draw(Cast cast)
        {
            cast.Draw();
        }
    }
}