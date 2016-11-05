using System;
using System.Collections.Generic;

namespace TennisScoring.Core.Domain
{
	public class Match
	{
		public Player Player1 { get; private set; }
		public Player Player2 { get; private set; }
		public int BestOf { get; private set; }

		// Even if it is best out of 5, might not need every game to be initialised, someone could win 3 straight games
		public List<Set> Sets { get; set; }
		public Set CurrentSet { get; set; }

		public Game CurrentGame { get { return CurrentSet.CurrentGame; } }

		public Match(Player player1, Player player2, int bestOf = 3)
		{
			Player1 = player1;
			Player2 = player2;
			BestOf = bestOf;

			var startingSet = new Set();
			Sets = new List<Set> { startingSet };
			CurrentSet = startingSet;
		}

		public void AddPoint(Player player)
		{
			if (player == null) throw new ArgumentNullException("player");
			if (Player1 == null) throw new ArgumentNullException("Player1");
			if (Player2 == null) throw new ArgumentNullException("Player2");

			// probably want a custom comparer here
			if (player.Equals(Player1)) { CurrentSet.AddPointToPlayer1(); }
			if (player.Equals(Player2)) { CurrentSet.AddPointToPlayer2(); }

			throw new Exception("Provided player is not playing in this game.");
		}

		// Not sure if this is needed - not hard for caller to do this
		public string DisplayCurrentGameScore()
		{
			return CurrentGame.DisplayScore();
		}

		// Not sure if this is needed - not hard for caller to do this
		public object DisplayCurrentSetScore()
		{
			return CurrentSet.DisplayScore();
		}
	}
}
