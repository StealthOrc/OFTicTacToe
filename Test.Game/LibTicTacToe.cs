using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Game
{
    public static class LibTicTacToe
    {
        public static float WorldCoord4GridCoord(int gridCoord)
        {
            if (gridCoord < 1)
                return -300;
            if (gridCoord == 1)
                return 0;
            return 300;

        }
    }
}
