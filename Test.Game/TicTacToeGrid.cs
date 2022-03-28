using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Events;

namespace Test.Game
{
    public class TicTacToeGrid: CompositeDrawable
    {
        private Container grid;
        private const float gridLineLength = 890;
        private const float gridLineWidth  = 10;

        private TicTacToeField[,] _TTTGrid;
        public TicTacToeField[,] TTTGrid { get => _TTTGrid; }        

        public TicTacToeGrid()
        {            
            AutoSizeAxes = Axes.Both;
            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;
            generateGridLines();
            generateTTTGrid();            
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            addGridFields();
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();            
        }

        private void generateGridLines()
        {
            InternalChild = grid = new Container
            {
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Children = new Drawable[]
                {
                    #region GridLines
                    // Left Vertical Line
                    new Box
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Colour = Colour4.Cornsilk,
                        Height = gridLineLength,
                        Width  = gridLineWidth,
                        X = -150
                    },
                    // Right Vertical Line
                    new Box
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Colour = Colour4.Cornsilk,
                        Height = gridLineLength,
                        Width  = gridLineWidth,
                        X = 150
                    },
                    // Top Horizontal Line
                    new Box
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Colour = Colour4.Cornsilk,
                        Width  = gridLineLength,
                        Height = gridLineWidth,
                        Y = -150
                    },
                    // Bottom Horizontal Line
                    new Box
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Colour = Colour4.Cornsilk,
                        Width  = gridLineLength,
                        Height = gridLineWidth,
                        Y = 150
                    },
                    #endregion
                }
            };
        }

        private void generateTTTGrid()
        {
            //generate UI Fields for grid
            _TTTGrid = new TicTacToeField[3, 3];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    _TTTGrid.SetValue(new TicTacToeField(LibTicTacToe.WorldCoord4GridCoord(x), LibTicTacToe.WorldCoord4GridCoord(y)), x, y);
                    _TTTGrid[x, y].Anchor = Anchor.Centre;
                    _TTTGrid[x, y].Origin = Anchor.Centre;
                    _TTTGrid[x, y].Name = "Field" + x + y;
                    //if (_TTTGrid != null)
                    //    AddInternal(_TTTGrid[x, y]);
                }
            }
        }

        private void addGridFields()
        {
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    AddInternal(_TTTGrid[x, y]);
        }

        public void Reset()
        {
            ClearInternal();
            generateGridLines();
            generateTTTGrid();
            addGridFields();
        }

        public void AssignField(int x, int y, FieldConstants field)
        {
            if (field == FieldConstants.O)
                _TTTGrid[x, y].AssignPlayerSign(new TicTacToeCircle());
            else if (field == FieldConstants.X)
                _TTTGrid[x, y].AssignPlayerSign(new TicTacToeCross());
        }
    }
}
