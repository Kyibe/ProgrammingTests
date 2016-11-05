using System;

namespace TennisScoring.Core.Domain
{
    // should this be internal?
    // Should this be interfaced, is there other ways to add points, are there different types of tennis games?
    public class Game
    {
        private int Player1GameScore { get; set; }

        private int Player2GameScore { get; set; }

        // dont think it makes sense for anyone to be able to increase the players score by one?
        // Is this a job of Match?
        // Should this therefore be in Match?
        public void AddPointToPlayer1()
        {
            AddPointToPlayer(true);
        }

        public void AddPointToPlayer2()
        {
            AddPointToPlayer(false);
        }

        // Is there a better option than a bool?
        // How does someone know that false means player2?
        private void AddPointToPlayer(bool player1)
        {
            if (player1)
            {
                Player1GameScore++;
            }
            else
            {
                Player2GameScore++;
            }
        }

        public string DisplayScore()
        {
            // Better way?
            return string.Format(
                "{0} - {1}",
                TranslateScore(Player1GameScore, Player2GameScore),
                TranslateScore(Player2GameScore, Player1GameScore));
        }

        private string TranslateScore(int score, int opponentsScore)
        {
            if (score == 1)
            {
                return "15";
            }

            if (score == 2)
            {
                return "30";
            }

            if (score == 3)
            {
                return "40";
            }

            if (score == opponentsScore)
            {
                return "deuce";
            }

            if (score + 1 == opponentsScore)
            {
                return string.Empty;
            }

            if (score - 1 == opponentsScore)
            {
                return "Advantage";
            }

            throw new Exception("Something has gone wrong with the scoring system");
        }
    }
}
