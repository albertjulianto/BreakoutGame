using SplashKitSDK;

namespace BreakoutGame
{
    public class Brick
    {
        public const int Width = 60;
        public const int Height = 20;
        public double X { get; set; }
        public double Y { get; set; }
        public bool IsHit { get; set; }

        public Brick(double x, double y)
        {
            X = x;
            Y = y;
            IsHit = false;
        }

        public void Draw()
        {
            if (!IsHit)
            {
                SplashKit.FillRectangle(Color.SeaGreen, X, Y, Width, Height);
            }
        }

        public void Hit()
        {
            IsHit = true;
        }

    }
}