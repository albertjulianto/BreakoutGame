using System;
using SplashKitSDK;

namespace BreakoutGame
{
    public class Program
    {
        public static void Main()
        {
            Window gameWindow = new Window("Breakout Game", 800, 600);
            Breakout breakout = new Breakout(gameWindow);
            breakout.Run();
        }
    }
}

