using SplashKitSDK;

namespace BreakoutGame
{
    public class Player
    {
        private int _width = 100;
        private int _height = 20;

        private int _lives = 5;

         private Window _gameWindow;

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public double X { get; set; }
        public double Y { get; set; }
        public int PlayerWidth
        {
            get { return _width; }

        }
        public double PlayerHeight
        {
            get { return _height; }
        }

        public bool Quit { get; private set; }

        public Player(Window gameWindow)
        {
            _gameWindow = gameWindow;
            X = (gameWindow.Width - _width) / 2;
            Y = 550;
        }

        public void Draw()
        {
            SplashKit.FillRectangle(Color.Aqua, X, Y, _width, _height);
        }

        public void Update()
        {
            if (SplashKit.KeyDown(KeyCode.LeftKey))
            {
                X -= 5;
            }
            if (SplashKit.KeyDown(KeyCode.RightKey))
            {
                X += 5;
            }
            if (SplashKit.KeyDown(KeyCode.EscapeKey))
            {
                Quit = true;
            }

            // check for out of bounds
            if (X < 0)
            {
                X = 0;
            }
            if (X > _gameWindow.Width - _width)
            {
                X = _gameWindow.Width - _width;
            }
        }
    }
}