using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// This unit contains the values of the game and serves as a vault to access the current game state.
/// </summary>

namespace Test.Game
{
    public enum FieldConstants
    {
        // whether or not the field is free to be assigned by a player
        Free = 'f',
        // Field assigned by player X
        X = 'x',
        // Field assigned by player O
        O = 'o'
    }

    public enum GameStates
    {
        Ready,  // game itself isnt running yet
        Running,    // game is running
        Pause,  // game is paused
        GameOver // game is over
    }

    public enum GameResults
    {
        Unclear,// result yet to be determined
        Tie,    // game is tied
        XWin,   // Player X won the game
        OWin    // Player O won the game
    }

    public enum PlayerTurn
    {
        X,
        O
    }

    public class TicTacToeGameState
    {

#pragma warning disable IDE0032 // Automatisch generierte Eigenschaft verwenden
        // the Tic tac toe field (x,y)
        private char[,] m_TTTGrid =     {
                                            {(char)FieldConstants.Free,(char)FieldConstants.Free,(char)FieldConstants.Free},
                                            {(char)FieldConstants.Free,(char)FieldConstants.Free,(char)FieldConstants.Free},
                                            {(char)FieldConstants.Free,(char)FieldConstants.Free,(char)FieldConstants.Free}
                                        };
#pragma warning restore IDE0032 // Automatisch generierte Eigenschaft verwenden

        public char[,] TTTGrid { get => m_TTTGrid; }

        // current state of the game
        private GameStates _State;        
        public GameStates State { get => _State; set => _State = value; }

        // Result of the game
        private GameResults _Result;
        public GameResults Result { get => _Result; }

        private PlayerTurn _Turn;
        public PlayerTurn Turn { get => _Turn; }

        /// <summary>
        /// Constructor
        /// </summary>
        public TicTacToeGameState()
        {
            _State = GameStates.Ready;
        }


        /// <summary>
        /// Readys(Resets) the entire Gamestate
        /// </summary>
        public void Reset()
        {
            _State  = GameStates.Ready;
            ClearResult();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    m_TTTGrid[i, j] = (char)FieldConstants.Free;
                }                
        }

        public void ClearResult()
        {
            _Result = GameResults.Unclear;
        }

        /// <summary>
        /// Assigns a Field in the grid the given sign.
        /// </summary>
        /// <param name="x">x coord starting from 0</param>
        /// <param name="y">y coord starting from 0</param>
        /// <param name="playersign">the type of Sign, either X or O</param>
        public bool AssignField(int x, int y )
        {
            FieldConstants currField;
            currField = (_Turn == PlayerTurn.O) ? FieldConstants.O : FieldConstants.X;
            //check if the field is already assigned
            if (currField == FieldConstants.Free ||
                (m_TTTGrid[x,y] == (char)FieldConstants.X || m_TTTGrid[x, y] == (char)FieldConstants.O))
                return false;
            //assign field
            m_TTTGrid[x, y] = (char)currField;
            switchTurn();
            return true;
        }

        public bool CheckGameOver()
        {
            bool result = true;
            //check if a win condition has taken place
            if (isTopRowWin())
                checkResult(m_TTTGrid[0, 0]);
            else if (isMidRowWin())
                checkResult(m_TTTGrid[0, 1]);
            else if (isBotRowWin())
                checkResult(m_TTTGrid[0, 2]);
            else if (isLefColWin())
                checkResult(m_TTTGrid[0, 0]);
            else if (isMidColWin())
                checkResult(m_TTTGrid[1, 0]);
            else if (isRigColWin())
                checkResult(m_TTTGrid[2, 0]);
            else if (isDiagWin())
                checkResult(m_TTTGrid[1, 1]);
            else
            {
                bool isTied = true;
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        isTied = (isTied && (m_TTTGrid[x, y] != (char)FieldConstants.Free));
                        if (!isTied)
                            return false;
                    }
                }
            }

            return true;

            bool isTopRowWin()
            {
                return m_TTTGrid[0, 0] != (char)FieldConstants.Free && (m_TTTGrid[0, 0] == m_TTTGrid[1, 0] && m_TTTGrid[1, 0] == m_TTTGrid[2, 0]);
            }
            bool isMidRowWin()
            {
                return m_TTTGrid[0, 1] != (char)FieldConstants.Free && (m_TTTGrid[0, 1] == m_TTTGrid[1, 1] && m_TTTGrid[1, 1] == m_TTTGrid[2, 1]);
            }
            bool isBotRowWin()
            {
                return m_TTTGrid[0, 2] != (char)FieldConstants.Free && (m_TTTGrid[0, 2] == m_TTTGrid[1, 2] && m_TTTGrid[1, 2] == m_TTTGrid[2, 2]);
            }
            bool isLefColWin()
            {
                return m_TTTGrid[0, 0] != (char)FieldConstants.Free && (m_TTTGrid[0, 0] == m_TTTGrid[0, 1] && m_TTTGrid[0, 1] == m_TTTGrid[0, 2]);
            }
            bool isMidColWin()
            {
                return m_TTTGrid[1, 0] != (char)FieldConstants.Free && (m_TTTGrid[1, 0] == m_TTTGrid[1, 1] && m_TTTGrid[1, 1] == m_TTTGrid[1, 2]);
            }
            bool isRigColWin()
            {
                return m_TTTGrid[2, 0] != (char)FieldConstants.Free && (m_TTTGrid[2, 0] == m_TTTGrid[2, 1] && m_TTTGrid[2, 1] == m_TTTGrid[2, 2]);
            }
            //check both diagonals
            bool isDiagWin()
            {
                return (m_TTTGrid[1, 1] != (char)FieldConstants.Free && (m_TTTGrid[0, 0] == m_TTTGrid[1, 1] && m_TTTGrid[1, 1] == m_TTTGrid[2, 2])) ||
                       (m_TTTGrid[1, 1] != (char)FieldConstants.Free && (m_TTTGrid[2, 0] == m_TTTGrid[1, 1] && m_TTTGrid[1, 1] == m_TTTGrid[0, 2]));
            }
            void checkResult(char field)
            {
                if (field == (char)FieldConstants.X)
                    _Result = GameResults.XWin;
                else
                    _Result = GameResults.OWin;
            }
        }

        private void switchTurn()
        {
            //switches the turn to the other player
            _Turn = (_Turn == PlayerTurn.X) ? PlayerTurn.O : PlayerTurn.X;
        }
    }
}
