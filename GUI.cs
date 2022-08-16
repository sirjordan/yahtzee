internal class GUI
{
	private Game _game;
	private int _lineLenght;
	private ConsoleColor _originalColor;
	private ConsoleColor _selectionColor;
	private bool _selectionMode;
	private int _selectedRow;
	private int _printedRow;

	public GUI(Game game)
	{
		_game = game;
		_lineLenght = 60;
		_originalColor = Console.ForegroundColor;
		_selectionColor = ConsoleColor.Magenta;
		_selectionMode = false;
		_selectedRow = 0;
		_printedRow = 0;

		if (OperatingSystem.IsWindows())
		{
			Console.SetWindowSize(1, 1);
			Console.SetBufferSize(160, 40);
			Console.SetWindowSize(160, 40);
		}
	}

	public void Welcome()
	{
		PrintLine();
		Console.WriteLine("Welcome to Yahtzee!");
		Console.WriteLine();
		Console.WriteLine("The game consists of a number of rounds. In each round, a player gets three rolls of the dice, although they can choose to end their turn after one or two rolls. After the first roll the player can save any dice they want and re-roll the other dice. This procedure is repeated after the second roll. The player has complete choice as to which dice to roll. It is possible to re-roll both dice that were or were not rolled before.");
		Console.WriteLine();
		Console.WriteLine("The Yahtzee scorecard contains 13 different category boxes and in each round, after the third roll, the player must choose one of these categories. The score entered in the box depends on how well the five dice match the scoring rule for the category. Details of the scoring rules for each category are given below. As an example, one of the categories is called Three of a Kind. The scoring rule for this category means that a player only scores if at least three of the five dice are the same value. The game is completed after 13 rounds by each player, with each of the 13 boxes filled. The total score is calculated by summing all thirteen boxes, together with any bonuses.");
		Console.WriteLine();
		Console.WriteLine("Learn more at https://en.wikipedia.org/wiki/Yahtzee");
		Console.WriteLine();
		PrintLine();
		// Help and other
		Console.WriteLine("Press any key to continue...");
	}

	public void Update()
	{
		Console.Clear();
		Console.WriteLine("Yahtzee!");
		Console.WriteLine($"Total: {_game.TotalScore}");
		Console.WriteLine();

		PrintBoard();
	}

	public void SelectionMode()
	{
		_selectionMode = !_selectionMode;
		_selectedRow = Convert.ToInt32(_selectionMode);
	}

	public void Select(int direction)
	{
		if (!_selectionMode)
		{
			return;
		}

		if (direction > 0 && _selectedRow < _game.Board.Rows.Length)
		{
			_selectedRow++;
		}
		else if (direction < 0 && _selectedRow > 1)
		{
			_selectedRow--;
		}
		else
		{
			return;
		}
	}

	private void PrintBoard()
	{
		_printedRow = 0;

		PrintLine();
		PrintBoardRow("CATEGORY", "DICES", "SCORE");
		PrintLine();

		foreach (var row in _game.Board.Rows)
		{
			PrintBoardRow(row.Name, FormatDices(row.Dices), 0);
			PrintLine();
		}
	}

	public void PrintDices(int[] dices)
	{
		Console.Write(FormatDices(dices));
	}

	private static string FormatDices(int[] dices)
	{
		var output = string.Empty;

		for (int j = 0; j < dices.Length; j++)
		{
			var dice = dices[j];
			var value = dice > 0 ? dice.ToString() : " ";
			output += $"[{value}]";

			if (j < dices.Length - 1)
			{
				output += " ";
			}
		}

		return output;
	}

	private void PrintBoardRow(object a, object b, object c)
	{
		if (_selectionMode && _printedRow == _selectedRow)
		{
			Console.ForegroundColor = _selectionColor;
		}

		Console.WriteLine(string.Format("{0, -18} | {1, -30} | {2, 5}", $"{a}", $"{b}", $"{c}"));
		Console.ForegroundColor = _originalColor;

		_printedRow++;
	}

	private void PrintLine()
	{
		for (int i = 0; i < _lineLenght; i++)
		{
			Console.Write("-");
		}

		Console.WriteLine();
	}
}
