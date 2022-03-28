using osu.Framework.Platform;
using osu.Framework;
using Test.Game;

namespace Test.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost(@"Test"))
            using (osu.Framework.Game game = new TestGame())
                host.Run(game);
        }
    }
}
