internal class Game
{
	public Board Board { get; private set; }
	public int TotalScore { get; private set; }
	public int Round { get; private set; }

	public Game()
	{
		Board = new Board();
		TotalScore = 0;
		Round = 0;
	}

	public int[] RollDices()
	{
		var dices = new int[5];
		var rnd = new Random();

		for (int i = 0; i < dices.Length; i++)
		{
			dices[i] = rnd.Next(1, 7);
		}

		return dices;
	}

	public bool Over()
	{
		return Round == Rules.Rounds;
	}
}
