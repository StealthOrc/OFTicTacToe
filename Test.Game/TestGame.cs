using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using osuTK;
using osuTK.Input;

namespace Test.Game
{
    public class TestGame : TestGameBase
    {
        private const float circleOverlayXPos   = -750f;
        private const float circleScoreXPos     = -500f;
        private const float crossOverlayXPos    = 750f;
        private const float crossScoreXPos      = 500f;

        private ScreenStack screenStack;
        private DrawSizePreservingFillContainer gameScreen = new DrawSizePreservingFillContainer();
        private ScoreTracker scoreCircle = new ScoreTracker(circleScoreXPos, 0f);
        private ScoreTracker scoreCross  = new ScoreTracker(crossScoreXPos, 0f);

        private TicTacToeGameState gameState;
        private Container backdrop;
        private TicTacToeGrid gameGrid;
        

        [BackgroundDependencyLoader]
        private void load()
        {
            gameState = new TicTacToeGameState();

            // Add your top-level game components here.
            // A screen stack and sample screen has been provided for convenience, but you can replace it if you don't want to use screens.
            Child = screenStack = new ScreenStack { RelativeSizeAxes = Axes.Both };

            gameScreen.Strategy = DrawSizePreservationStrategy.Minimum;
            gameScreen.TargetDrawSize = new Vector2(1080, 1080);

            createBackdrop();
            foreach (TicTacToeSign sign in backdrop.Children)
            {
                if (sign is TicTacToeCircle)
                    ((TicTacToeCircle)sign).SetAlpha(0.5f);
                else
                    sign.Alpha = 0.5f;
            }
            //((TicTacToeCircle)backdrop.Children[0]).SetAlpha(0.5f);
            gameGrid = new TicTacToeGrid();
            gameScreen.Add(backdrop);
            gameScreen.Add(gameGrid);
            gameScreen.Add(scoreCircle.ScoreSpriteText);
            gameScreen.Add(scoreCross.ScoreSpriteText);

            AddInternal(gameScreen);

            void createBackdrop()
            {
                backdrop = new Container()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Children = new Drawable[]
                    {
                        new TicTacToeCircle()
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            X = circleOverlayXPos,
                            Y = 0f,
                            Scale = new Vector2(1.3f,1.3f),
                        },
                        //1CR
                        new TicTacToeCross()
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Alpha = 0.5f,
                            X = crossOverlayXPos,
                            Y = 0f,
                            Scale = new Vector2(1.3f,1.3f),
                        },
                    }
                };
            }
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
        }

        /// <summary>
        /// runs any updates, handling input, game logic, core loop
        /// </summary>
        protected override void Update()
        {
            base.Update();

            switch (gameState.State)
            {
                case GameStates.Ready:
                    changeGameState(GameStates.Running);
                    break;
                case GameStates.Running:
                    if (gameState.CheckGameOver())
                        changeGameState(GameStates.GameOver);
                    break;
                case GameStates.Pause:
                    // TODO: SHOW PAUSE MESSAGE/MENU                    
                    break;
                case GameStates.GameOver:                    
                    switch (gameState.Result)
                    {
                        case GameResults.Tie:
                            // TODO: Show Tie message
                            gameState.ClearResult();
                            break;
                        case GameResults.OWin:
                            // TODO: Show OWin message
                            scoreCircle.IncrementScore();
                            gameState.ClearResult();
                            break;
                        case GameResults.XWin:
                            // TODO: Show XWin message
                            scoreCross.IncrementScore();
                            gameState.ClearResult();
                            break;
                        default:
                            break;
                    }
                    //Do nothing, we will return to ready once button was pressed
                    //TODO: Show message that you can begin next round pressing any key
                    //changeGameState(GameStates.Ready);
                    break;
                default:
                    break;
            }
        }

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            if(e.Repeat)
                return base.OnKeyDown(e);
            switch (gameState.State)
            {
                case GameStates.GameOver:
                    changeGameState(GameStates.Ready);
                    break;
                default:
                    break;
            }

            switch (e.Key)
            {
                case Key.Keypad1:
                    assignField(0, 2);
                    break;
                case Key.Keypad2:
                    assignField(1, 2);
                    break;
                case Key.Keypad3:
                    assignField(2, 2);
                    break;
                case Key.Keypad4:
                    assignField(0, 1);
                    break;
                case Key.Keypad5:
                    assignField(1, 1);
                    break;
                case Key.Keypad6:
                    assignField(2, 1);
                    break;
                case Key.Keypad7:
                    assignField(0, 0);
                    break;
                case Key.Keypad8:
                    assignField(1, 0);
                    break;
                case Key.Keypad9:
                    assignField(2, 0);
                    break;
                default:
                    break;
            }

            return base.OnKeyDown(e);
        }

        protected override bool OnClick(ClickEvent e)
        {            
            return base.OnClick(e);
        }

        /// <summary>
        /// changes the gamestate to the given new state
        /// </summary>
        /// <param name="newState"></param>
        private void changeGameState(GameStates newState)
        {
            if (newState == gameState.State)
                return;

            gameState.State = newState;

            switch (newState)
            {
                case GameStates.Ready:
                    ready();
                    gameState.Reset();
                    break;

                case GameStates.Running:
                    run();
                    break;

                case GameStates.Pause:
                    pause();
                    break;
            }
        }

        private void ready()
        {
            gameState.Reset();
            gameGrid.Reset();
        }

        private void run()
        {
            scoreCircle.Start();
            scoreCross.Start();
        }

        private void pause()
        {
            
        } 

        private void assignField(int x, int y)
        {
            PlayerTurn currTurn = gameState.Turn;
            if (gameState.AssignField(x, y))
            {
                if (currTurn == PlayerTurn.O)
                {
                    gameGrid.AssignField(x, y, FieldConstants.O);                    
                }
                //gameScreen.Add(new TicTacToeCircle(LibTicTacToe.WorldCoord4GridCoord(x), LibTicTacToe.WorldCoord4GridCoord(y)));
                else
                    gameGrid.AssignField(x, y, FieldConstants.X);
                //gameScreen.Add(new TicTacToeCross(LibTicTacToe.WorldCoord4GridCoord(x), LibTicTacToe.WorldCoord4GridCoord(y)));
            }
        }
    }
}
