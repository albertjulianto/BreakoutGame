using System.Collections.Generic;
using SplashKitSDK;

namespace BreakoutGame
{
    public class Breakout
    {
        private Player _player;
        private Ball _ball;
        private List<Brick> _bricks;
        private Window _gameWindow;
        private int _score;
        private bool _allBricksHit;

        public Player Player
        {
            get
            {
                return _player;
            }
        }
        public bool Quit
        {
            get
            {
                return _player.Quit;
            }
        }

        public Breakout(Window gameWindow)
        {
            _gameWindow = gameWindow;
            _player = new Player(_gameWindow);
            _ball = new Ball(_gameWindow);
            _bricks = new List<Brick>();
            _score = 0;
            _allBricksHit = false;

            // Initialize bricks
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    _bricks.Add(new Brick(j * (Brick.Width + 10) + 10, i * (Brick.Height + 10) + 10));
                }
            }
        }

        public void Run()
        {
            while (!SplashKit.WindowCloseRequested("Breakout Game") && _player.Lives > 0 && !Quit && !_allBricksHit)
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);

                _player.Update();

                int combo = _ball.Update(_player, _bricks);

                _score += combo * 10; // Each brick hit gives 10 points to the score

                _player.Draw();
                _ball.Draw();

                foreach (Brick brick in _bricks)
                {
                    brick.Draw();
                }

                DrawLives();
                DrawScore();

                // Check if all bricks are hit
                if (!_allBricksHit && AllBricksHit())
                {
                    _allBricksHit = true;
                }

                if (_allBricksHit)
                {
                    TheEnd();
                }

                SplashKit.RefreshScreen(60);
            }

            if (_player.Lives <= 0)
            {
                GameOver();
            }
        }

        //check if all bricks have been hit
        private bool AllBricksHit()
        {
            foreach (Brick brick in _bricks)
            {
                if (!brick.IsHit)
                {
                    return false;
                }
            }
            return true;
        }

        private void TheEnd()
        {
            SplashKit.ClearScreen(Color.Black);
            SplashKit.DrawText("Congratulations! You cleared all the bricks!", Color.Green, "Arial", 150, 100, 250);
            SplashKit.DrawText($"Final Score = {_score}", Color.Yellow, "Arial", 150, 250, 300);
            SplashKit.RefreshScreen();
            SplashKit.Delay(3000);
        }

        private void DrawLives()
        {
            string livesText = $"Lives: {_player.Lives}";
            SplashKit.DrawText(livesText, Color.White, "Arial", 50, 10, 570);
        }

        private void DrawScore()
        {
            string scoreText = $"Score: {_score}";
            SplashKit.DrawText(scoreText, Color.White, "Arial", 50, 700, 570);
        }

        private void GameOver()
        {
            SplashKit.ClearScreen(Color.Black);
            SplashKit.DrawText("Game Over", Color.Red, "Arial", 150, 250, 250);
            SplashKit.DrawText($"Final Score = {_score}", Color.Yellow, "Arial", 150, 250, 300);
            SplashKit.RefreshScreen();
            SplashKit.Delay(3000);
        }
    }
}