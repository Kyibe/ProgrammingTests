using NUnit.Framework;
using System;

namespace UnitTests.TennisScoring
{
	[TestFixture]
	public class TennisScoringUnitTests
	{
		private Player _player1;
		private Player _player2;
		private Game _tennisMatch;

		[SetUp]
		public void SetUp()
		{
			_player1 = new Player("player", "one");
			_player2 = new Player("player", "two");
			_tennisMatch = new Game(_player1, _player2);
		}

		[Test]
		public void AddPointTo_WherePlayer2WinsAfterPlayer1HasAdvantage_ShouldProduceDeuce()
		{
			//arrange
			MakeMatchDeuce();
			_tennisMatch.AddPointTo(_player1);

			//act
			_tennisMatch.AddPointTo(_player2);

			//assert
			var score = _tennisMatch.Score;
			Assert.That(score.GetGameScore(), Is.EqualTo("Deuce - Deuce"));
		}

		[Test]
		public void AddPointTo_WherePlayer1WinsAfterAdvantage_ShouldProduceANewGame()
		{
			//arrange
			MakeMatchDeuce();
			_tennisMatch.AddPointTo(_player1);

			//act
			_tennisMatch.AddPointTo(_player1);

			//assert
			var score = _tennisMatch.Score;
			Assert.That(score.GetGameScore(), Is.EqualTo("0 - 0"));
		}

		[Test]
		public void AddPointTo_WherePlayer2GetsAdvantage_ShouldProduceAdvantage()
		{
			//arrange
			MakeMatchDeuce();

			//act
			_tennisMatch.AddPointTo(_player1);

			//assert
			var score = _tennisMatch.Score;
			Assert.That(score.GetGameScore(), Is.EqualTo(" - Advantage"));
		}

		[Test]
		public void AddPointTo_WherePlayer1GetsAdvantage_ShouldProduceAdvantage()
		{
			//arrange
			MakeMatchDeuce();

			//act
			_tennisMatch.AddPointTo(_player1);

			//assert
			var score = _tennisMatch.Score;
			Assert.That(score.GetGameScore(), Is.EqualTo("Advantage - "));
		}

		[Test]
		public void AddPointTo_WhereThreePointsEach_ShouldProduceDeuce()
		{
			//arrange
			//act
			MakeMatchDeuce();

			//assert
			var score = _tennisMatch.Score;
			Assert.That(score.GetGameScore(), Is.EqualTo("Deuce - Deuce"));
		}

		private void MakeMatchDeuce()
		{
			_tennisMatch.AddPointTo(_player1);
			_tennisMatch.AddPointTo(_player1);
			_tennisMatch.AddPointTo(_player1);

			_tennisMatch.AddPointTo(_player2);
			_tennisMatch.AddPointTo(_player2);
			_tennisMatch.AddPointTo(_player2);
		}

		[Test]
		public void AddPointTo_WhereFourthPoint()
		{
			//arrange
			_tennisMatch.AddPointTo(_player1);
			_tennisMatch.AddPointTo(_player1);
			_tennisMatch.AddPointTo(_player1);

			//act
			_tennisMatch.AddPointTo(_player1);

			//assert
			var score = _tennisMatch.Score;
			Assert.That(score.GetGameScore(), Is.EqualTo("0 - 0"));
		}

		[Test]
		public void AddPointTo_WhereThirdPoint()
		{
			//arrange
			_tennisMatch.AddPointTo(_player1);
			_tennisMatch.AddPointTo(_player1);

			//act
			_tennisMatch.AddPointTo(_player1);

			//assert
			var score = _tennisMatch.Score;
			Assert.That(score.GetGameScore(), Is.EqualTo("40 - 0"));
		}

		[Test]
		public void AddPointTo_WhereSecondPoint()
		{
			//arrange
			_tennisMatch.AddPointTo(_player1);

			//act
			_tennisMatch.AddPointTo(_player1);

			//assert
			var score = _tennisMatch.Score;
			Assert.That(score.GetGameScore(), Is.EqualTo("30 - 0"));
		}

		[Test]
		public void AddPointTo_WhereFirstPoint()
		{
			//arrange

			//act
			_tennisMatch.AddPointTo(_player1);

			//assert
			var score = _tennisMatch.Score;
			Assert.That(score.GetGameScore(), Is.EqualTo("15 - 0"));
		}

		[Test]
		[ExpectedException(typeof(ArgumentException), ExpectedMessage = "Player is not playing in this match.")]
		public void AddPointTo_WherePlayerNotInMatch_ShouldThrowError()
		{
			//arrange
			//act
			_tennisMatch.AddPointTo(new Player("wrong", "player"));
		}
	}

	//Think score and match are the same thing so should be merged into one class
	public class Game
	{
		private Player Player1 { get; set; }
		private Player Player2 { get; set; }
		public Score Score { get; set; }

		public Game(Player _player1, Player _player2)
		{
			Player1 = _player1;
			Player2 = _player2;
			Score = new Score(Player1, Player2);
		}

		public void AddPointTo(Player player)
		{
			throw new NotImplementedException();
		}
	}

	//Think score and match are the same thing so should be merged into one class
	public class Score
	{
		private Player Player1 { get; set; }
		private Player Player2 { get; set; }

		public Score(Player _player1, Player _player2)
		{
			Player1 = _player1;
			Player2 = _player2;
		}

		internal object GetGameScore()
		{
			throw new NotImplementedException();
		}
	}

	public class Player
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public Player(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}
	}
}
