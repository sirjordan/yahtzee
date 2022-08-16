internal class Game
{
	public int SelectedRow { get; private set; }
	public bool SelectionMode { get; private set; }

	public Board Board { get; private set; }
	public int Round { get; private set; }
	public int[] RolledDices { get; private set; }

	public Game()
	{
		Board = new Board();
		Round = 0;
		RolledDices = new int[Rules.NumberOfDices];

		SelectionMode = false;
		SelectedRow = 0;
	}

	public void TurnSelectionMode()
	{
		if (SelectionMode && RolledDices.All(d => d != 0))
		{
			if (!Board.Rows[SelectedRow - 1].Set)
			{
				Board.Rows[SelectedRow - 1].Dices = RolledDices;
				Round++;
			}
		}

		SelectionMode = !SelectionMode;
		SelectedRow = Convert.ToInt32(SelectionMode);
	}

	public void Select(int direction)
	{
		if (!SelectionMode)
		{
			return;
		}

		if (direction > 0 && SelectedRow < Board.Rows.Length)
		{
			SelectedRow++;

		}
		else if (direction < 0 && SelectedRow > 1)
		{
			SelectedRow--;
		}
		else
		{
			return;
		}

		if (Board.Rows[SelectedRow - 1].Set)
		{
			Select(direction);
		}
	}

	public void RollDices()
	{
		var dices = new int[Rules.NumberOfDices];
		var rnd = new Random();

		for (int i = 0; i < dices.Length; i++)
		{
			dices[i] = rnd.Next(1, 7);
		}

		RolledDices = dices;
	}

	public int GetTotalScore()
	{
		return Board.Rows.Sum(r => r.CalcScore());
	}

	public bool IsOver()
	{
		return Round == Rules.Rounds;
	}
}
