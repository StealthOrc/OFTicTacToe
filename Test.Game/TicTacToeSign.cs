using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK.Graphics;

namespace Test.Game
{
    public class TicTacToeSign : CompositeDrawable
    {
        protected Container SignContainer;

        public TicTacToeSign()
        {
            AutoSizeAxes = Axes.Both;
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            InternalChild = SignContainer = new Container
            {
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            };
        }

        [BackgroundDependencyLoader]
        private void load()
        {
           
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
        }
    }
}
