using NUnit.Framework;

namespace UnitTests.Core.TennisPlayerTests
{
	[TestFixture]
	public class AddPointUnitTests
	{
		private Player _player1;
		private Player _player2;
		private Match _match;

		[SetUp]
		public void SetUp()
		{
			_player1 = new Player { FirstName = "john" };
			_player2 = new Player { FirstName = "Chloe" };
			_match = new Match(_player1, _player2);
		}

		// Probably means that this want to be two different test files
		#region Game Tests

		[Test]
		public void _WherePlayer2WinsAfterPlayer1HasAdvantage_ShouldProduceDeuce()
		{
			// arrange
			MakeMatchDeuce();
			_match.AddPoint(_player1);

			// act
			_match.AddPoint(_player2);

			// assert
			Assert.That(_match.DisplayCurrentGameScore(), Is.EqualTo("Deuce - Deuce"));
			Assert.That(_match.DisplayCurrentSetScore(), Is.EqualTo("0 - 0"));
		}

		[Test]
		public void _WherePlayer1WinsAfterAdvantage_ShouldProduceANewGame()
		{
			// arrange
			MakeMatchDeuce();
			_match.AddPoint(_player1);

			// act
			_match.AddPoint(_player1);

			// assert
			Assert.That(_match.DisplayCurrentGameScore(), Is.EqualTo("0 - 0"));
			Assert.That(_match.DisplayCurrentSetScore(), Is.EqualTo("1 - 0"));
		}

		[Test]
		public void _WherePlayer2GetsAdvantage_ShouldProduceAdvantage()
		{
			// arrange
			MakeMatchDeuce();

			// act
			_match.AddPoint(_player1);

			// assert
			Assert.That(_match.DisplayCurrentGameScore(), Is.EqualTo(" - Advantage"));
			Assert.That(_match.DisplayCurrentSetScore(), Is.EqualTo("0 - 0"));
		}

		[Test]
		public void _WherePlayer1GetsAdvantage_ShouldProduceAdvantage()
		{
			// arrange
			MakeMatchDeuce();

			// act
			_match.AddPoint(_player1);

			// assert
			Assert.That(_match.DisplayCurrentGameScore(), Is.EqualTo("Advantage - "));
			Assert.That(_match.DisplayCurrentSetScore(), Is.EqualTo("0 - 0"));
		}

		[Test]
		public void _WhereThreePointsEach_ShouldProduceDeuce()
		{
			// arrange
			// act
			MakeMatchDeuce();

			// assert
			Assert.That(_match.DisplayCurrentGameScore(), Is.EqualTo("Deuce - Deuce"));
			Assert.That(_match.DisplayCurrentSetScore(), Is.EqualTo("0 - 0"));
		}

		private void MakeMatchDeuce()
		{
			_match.AddPoint(_player1);
			_match.AddPoint(_player1);
			_match.AddPoint(_player1);

			_match.AddPoint(_player2);
			_match.AddPoint(_player2);
			_match.AddPoint(_player2);
		}

		[Test]
		public void _WhereFourthPoint()
		{
			// arrange
			_match.AddPoint(_player1);
			_match.AddPoint(_player1);
			_match.AddPoint(_player1);

			// act
			_match.AddPoint(_player1);

			// assert
			Assert.That(_match.DisplayCurrentGameScore(), Is.EqualTo("0 - 0"));
			Assert.That(_match.DisplayCurrentSetScore(), Is.EqualTo("1 - 0"));
		}

		[Test]
		public void _WhereThirdPoint()
		{
			// arrange
			_match.AddPoint(_player1);
			_match.AddPoint(_player1);

			// act
			_match.AddPoint(_player1);

			// assert
			Assert.That(_match.DisplayCurrentGameScore(), Is.EqualTo("40 - 0"));
			Assert.That(_match.DisplayCurrentSetScore(), Is.EqualTo("0 - 0"));
		}

		[Test]
		public void _WhereSecondPoint()
		{
			// arrange
			_match.AddPoint(_player1);

			// act
			_match.AddPoint(_player1);

			// assert
			Assert.That(_match.DisplayCurrentGameScore(), Is.EqualTo("30 - 0"));
			Assert.That(_match.DisplayCurrentSetScore(), Is.EqualTo("0 - 0"));
		}

		[Test]
		public void _WhereFirstPoint()
		{
			// arrange
			// act
			_match.AddPoint(_player1);

			// assert
			Assert.That(_match.DisplayCurrentGameScore(), Is.EqualTo("15 - 0"));
			Assert.That(_match.DisplayCurrentSetScore(), Is.EqualTo("0 - 0"));
		}

		#endregion
	}
}
