using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Game
{
    public class ScoreTracker
    {
        /// <summary>
        /// The current number of points the player has. This is the source of
        /// truth for all of the score state in the game.
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// A text sprite that shows the current score.
        /// </summary>
        public readonly ScoreSpriteText ScoreSpriteText = new ScoreSpriteText();

        public ScoreTracker(float textPosX, float textPosY)
        {
            ScoreSpriteText.X = textPosX;
            ScoreSpriteText.Y = textPosY;
        }

        public void Reset()
        {
            Score = 0;
            ScoreSpriteText.Text = "0";
            ScoreSpriteText.Hide();
        }

        public void Start()
        {
            ScoreSpriteText.Show();
        }

        public void IncrementScore()
        {
            Score++;
            ScoreSpriteText.Text = Score.ToString();
        }
    }
}
