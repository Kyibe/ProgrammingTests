using System.Collections.Generic;

namespace TennisScoring.Core.Domain
{
	public class Set
	{
		private int Player1SetScore { get; set; }
		private int Player2SetScore { get; set; }

		public List<Game> Games { get; set; }
		public Game CurrentGame { get; set; }

		public Set()
		{
			var firstGame = new Game();
			Games = new List<Game> { firstGame };
			CurrentGame = firstGame;
		}

		// dont think it makes sense for anyone to be able to increase the players score by one?
		// Is this a job of Match?
		// Should this therefore be in Match?
		public void AddPointToPlayer1()
		{
			CurrentGame.AddPointToPlayer1();
		}

		public void AddPointToPlayer2()
		{
			CurrentGame.AddPointToPlayer2();
		}

		public object DisplayScore()
		{
			return string.Format("{0} - {1}", Player1SetScore, Player2SetScore);
		}
	}
}
