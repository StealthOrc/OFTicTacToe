using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK.Graphics;

namespace Test.Game
{
    public class TicTacToeCircle : TicTacToeSign
    {

        public TicTacToeCircle() : base()
        {
            SignContainer.Add(new Circle
            {
                Origin = Anchor.Centre,
                Anchor = Anchor.Centre,
                Colour = Color4.Blue,
                Width = 280,
                Height = 280,
            });
            SignContainer.Add(new Circle
            {
                Origin = Anchor.Centre,
                Anchor = Anchor.Centre,
                Colour = Color4.Black,
                Width = 240,
                Height = 240,
            });
        }

        [BackgroundDependencyLoader]
        private void load()
        {

        }
        public void SetAlpha(float alpha)
        {
            SignContainer[0].Alpha = alpha;
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
        }
    }
}
