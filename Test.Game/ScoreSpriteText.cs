using System.Threading.Tasks;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Text;

namespace Test.Game
{
    /// <summary>
    /// Draws the current score on screen. The score is displayed by using a glyph store
    /// to load the appropriate character images and display them like text on-screen.
    /// </summary>
    public class ScoreSpriteText : SpriteText
    {

        public ScoreSpriteText()
        {
            Text = "0";
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Font = FontUsage.Default.With(size: 100);

            RelativePositionAxes = Axes.Y;
            Y = -0.4f;            
        }
    }
}

