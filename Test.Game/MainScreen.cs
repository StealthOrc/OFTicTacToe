using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using osuTK.Graphics;

namespace Test.Game
{
    public class MainScreen : Screen
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
//                new Box
//                {
//                    Colour = Color4.Violet,
//                    RelativeSizeAxes = Axes.Both,
//                },
//                new SpriteText
//                {
//                    Y = 20,
//                    Text = "Main Screen",
//                    Anchor = Anchor.TopCentre,
//                    Origin = Anchor.TopCentre,
//                    Font = FontUsage.Default.With(size: 40)
//                },
//                new TicTacToeGrid
//                {
//                    Anchor = Anchor.Centre,
//                },
//                new TicTacToeCircle
//                {
//                    Anchor = Anchor.Centre,
//                    X = -300,
//                }
            };
        }
    }
}
