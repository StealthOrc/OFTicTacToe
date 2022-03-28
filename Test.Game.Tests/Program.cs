using osu.Framework;
using osu.Framework.Platform;

namespace Test.Game.Tests
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost("visual-tests"))
            using (var game = new TestTestBrowser())
                host.Run(game);
        }
    }
}
