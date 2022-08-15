internal class GUI
{
	private Game _game;
	private int _lineLenght;

	public GUI(Game game)
	{
		_game = game;
		_lineLenght = 60;
	}

	public void PrintBoard()
	{
		PrintDashedLine();
		PrintRow("CATEGORY", "DICES", "SCORE");
		
		PrintDashedLine();
		PrintRow("Aces", FormatDices(_game.Board.Aces), 17);
		PrintDashedLine();
		PrintRow("Twos", FormatDices(_game.Board.Twos), 4);
		PrintDashedLine();
		PrintRow("Threes", FormatDices(_game.Board.Threes), 4);
		PrintDashedLine();
		PrintRow("Fours", FormatDices(_game.Board.Fours), 4);
		PrintDashedLine();
		PrintRow("Fives", FormatDices(_game.Board.Fives), 4);
		PrintDashedLine();
		PrintRow("Sixes", FormatDices(_game.Board.Sixes), 4);
		PrintDashedLine();
		PrintRow("Three Of A Kind", FormatDices(_game.Board.ThreeOfAKind), 4);
		PrintDashedLine();
		PrintRow("Four Of A Kind", FormatDices(_game.Board.FourOfAKind), 4);
		PrintDashedLine();
		PrintRow("Full House", FormatDices(_game.Board.FullHouse), 4);
		PrintDashedLine();
		PrintRow("Small Straight", FormatDices(_game.Board.SmallStraight), 4);
		PrintDashedLine();
		PrintRow("Large Straight", FormatDices(_game.Board.LargeStraight), 4);
		PrintDashedLine();
		PrintRow("Yahtzee", FormatDices(_game.Board.Yahtzee), 4);
		PrintDashedLine();
		PrintRow("Chance", FormatDices(_game.Board.Chance), 4);

		PrintDashedLine();
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

	private void PrintRow(object a, object b, object c)
	{
		Console.WriteLine(string.Format("{0, -18} | {1, -30} | {2, 5}", $"{a}", $"{b}", $"{c}"));
	}

	private void PrintDashedLine()
	{
		for (int i = 0; i < _lineLenght; i++)
		{
			Console.Write("-");
		}

		Console.WriteLine();
	}

	private void PrintSolidLine()
	{
		for (int i = 0; i < _lineLenght; i++)
		{
			Console.Write("_");
		}

		Console.WriteLine();
	}
}
