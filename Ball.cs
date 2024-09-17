using SplashKitSDK;

namespace BreakoutGame
{
    public class Ball
    {
        private double _x, _y, _velocityX, _velocityY;

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        private const int Size = 20;
        private Window _gameWindow;

        public Ball(Window gameWindow)
        {
            _gameWindow = gameWindow;
            Reset();
        }

        public void Draw()
        {
            SplashKit.FillCircle(Color.Salmon, _x, _y, Size / 2);
        }

        public int Update(Player player, List<Brick> bricks)
        {
            int combo = 0;
            _x += _velocityX;
            _y += _velocityY;

            // Bounce off walls
            if (_x <= 0 || _x >= _gameWindow.Width - Size)
            {
                _velocityX = -_velocityX;
            }
            if (_y <= 0)
            {
                _velocityY = -_velocityY;
            }

            // Check if the ball hit the player to bounce the ball from the player
            if (SplashKit.RectanglesIntersect(SplashKit.RectangleFrom(_x, _y, Size, Size), SplashKit.RectangleFrom(player.X, player.Y, player.PlayerWidth, player.PlayerHeight)))
            {
                //reverse the ball vertcial velocity to make it bounce back up
                _velocityY = -_velocityY;

                // Update the ball slightly above the player to prevent multiple collision detection
                _y = player.Y - Size;
            }

            // Bounce off bricks
            foreach (Brick brick in bricks)
            {
                if (!brick.IsHit && SplashKit.RectanglesIntersect(SplashKit.RectangleFrom(_x, _y, Size, Size), SplashKit.RectangleFrom(brick.X, brick.Y, Brick.Width, Brick.Height)))
                {
                    _velocityY = -_velocityY;
                    brick.Hit();
                    combo++;
                }
            }

            // Ball goes out of bounds
            if (_y > _gameWindow.Height)
            {
                player.Lives--;
                Reset();
            }
            return combo;
        }

        public void Reset()
        {
            _x = 400;
            _y = 300;
            _velocityX = 4;
            _velocityY = 4;

        }
    }
}