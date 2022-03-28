using osu.Framework.Testing;

namespace Test.Game.Tests.Visual
{
    public class TestTestScene : TestScene
    {
        protected override ITestSceneTestRunner CreateRunner() => new TestTestSceneTestRunner();

        private class TestTestSceneTestRunner : TestGameBase, ITestSceneTestRunner
        {
            private TestSceneTestRunner.TestRunner runner;

            protected override void LoadAsyncComplete()
            {
                base.LoadAsyncComplete();
                Add(runner = new TestSceneTestRunner.TestRunner());
            }

            public void RunTestBlocking(TestScene test) => runner.RunTestBlocking(test);
        }
    }
}
