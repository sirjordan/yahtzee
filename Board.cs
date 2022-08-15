internal class Board
{
	// Upper Section
	public int[] Aces { get; private set; }
	public int[] Twos { get; private set; }
	public int[] Threes { get; private set; }
	public int[] Fours { get; private set; }
	public int[] Fives { get; private set; }
	public int[] Sixes { get; private set; }

	// Lower Section
	public int[] ThreeOfAKind { get; private set; }
	public int[] FourOfAKind { get; private set; }
	public int[] FullHouse { get; private set; }
	public int[] SmallStraight { get; private set; }
	public int[] LargeStraight { get; private set; }
	public int[] Yahtzee { get; private set; }
	public int[] Chance { get; private set; }

	public int[] Save { get; private set; }

	public Board()
	{
		Aces = new int[Rules.NumberOfDices];
		Twos = new int[Rules.NumberOfDices];
		Threes = new int[Rules.NumberOfDices];
		Fours = new int[Rules.NumberOfDices];
		Fives = new int[Rules.NumberOfDices];
		Sixes = new int[Rules.NumberOfDices];

		ThreeOfAKind = new int[Rules.NumberOfDices];
		FourOfAKind = new int[Rules.NumberOfDices];
		FullHouse = new int[Rules.NumberOfDices];
		SmallStraight = new int[Rules.NumberOfDices];
		LargeStraight = new int[Rules.NumberOfDices];
		Yahtzee = new int[Rules.NumberOfDices];
		Chance = new int[Rules.NumberOfDices];

		Save = new int[Rules.NumberOfDices];
	}
}
