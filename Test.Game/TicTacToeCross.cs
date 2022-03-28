using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK.Graphics;

namespace Test.Game
{
    public class TicTacToeCross : TicTacToeSign
    {

        public TicTacToeCross() : base()
        {
            SignContainer.Add(new Box
            {
                Origin = Anchor.Centre,
                Anchor = Anchor.Centre,
                Colour = Color4.Red,
                Width = 20,
                Height = 320,
                Rotation = 45,
            });
            SignContainer.Add(new Box
            {
                Origin = Anchor.Centre,
                Anchor = Anchor.Centre,
                Colour = Color4.Red,
                Width  = 20,
                Height = 320,
                Rotation = 135,
            });
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
