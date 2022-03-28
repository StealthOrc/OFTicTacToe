using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Events;
using osuTK.Graphics;

namespace Test.Game
{
    public class TicTacToeField : CompositeDrawable
    {
        private Container fieldContainer;
        private const float unselected = 0.001f;
        private const float selected   = 0.1f;


        public TicTacToeField(float x, float y)
        {
            AutoSizeAxes = Axes.Both;
            Origin = Anchor.Centre;
            X = x;
            Y = y;
            setupFieldContainer();
        }

        protected override bool OnHover(HoverEvent e)
        {
            fieldContainer.Children[1].FadeTo(selected);
            return base.OnHover(e);            
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            fieldContainer.Children[1].FadeTo(unselected);
            base.OnHoverLost(e);            
        }

        private void setupFieldContainer()
        {
            InternalChild = fieldContainer = new Container
            {
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Children = new Drawable[]
                {
                    new Container
                    {
                        Name = "FieldContainer",
                        Origin = Anchor.Centre,
                        Anchor = Anchor.Centre,
                        Width = 290,
                        Height = 290,
                    },
                    new Box
                    {
                        Name = "HighlightBox",
                        Origin = Anchor.Centre,
                        Anchor = Anchor.Centre,
                        Colour = Color4.WhiteSmoke,
                        Width = 290,
                        Height = 290,
                    },
                }
            };
        }

        [BackgroundDependencyLoader]
        private void load()
        {            
            if (fieldContainer == null)
                setupFieldContainer();
            fieldContainer.Children[1].FadeTo(unselected);
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
        }

        public void AssignPlayerSign(TicTacToeSign playerSign)
        {
            if (!(playerSign is TicTacToeCircle) && !(playerSign is TicTacToeCross))
                return;
            ((Container)fieldContainer.Children[0]).Add(playerSign);
        }

        protected override bool OnClick(ClickEvent e)
        {
            //TODO: Somehow give  this to the grid so the grid can assign a sign to the field
            return base.OnClick(e);
        }
    }
}
