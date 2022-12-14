internal class GUI
{
	private Game _game;
	private int _lineLenght;
	private ConsoleColor _originalColor;
	private ConsoleColor _selectionColor;
	private int _printedRow;

	public GUI(Game game)
	{
		_game = game;
		_lineLenght = 60;
		_originalColor = Console.ForegroundColor;
		_selectionColor = ConsoleColor.Magenta;
		_printedRow = 0;

		if (OperatingSystem.IsWindows())
		{
			Console.SetWindowSize(1, 1);
			Console.SetBufferSize(160, 44);
			Console.SetWindowSize(160, 44);
			Console.SetWindowPosition(0, 0);
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
		Console.WriteLine("Yahtzee!    [SpaceBar] Roll    [Enter] Select");

		Console.WriteLine();
		Console.WriteLine($"ROLL {FormatDices(_game.RolledDices)}");
		Console.WriteLine();

		PrintBoard();
	}

	public void GameOver()
	{
		Console.WriteLine("GAME OVER! THANK YOU FOR PLAYING!");
	}

	private void PrintBoard()
	{
		_printedRow = 0;

		PrintLine();
		PrintBoardRow("CATEGORY", "DICES", "SCORE");
		PrintLine();

		foreach (var row in _game.Board.Rows)
		{
			PrintBoardRow(row.Name, FormatDices(row.Dices), row.CalcScore());
			PrintLine();
		}

		PrintBoardRow("TOTAL", "", _game.GetTotalScore());
		PrintLine();
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
		if (_game.SelectionMode && _printedRow == _game.SelectedRow)
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
