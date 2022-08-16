internal class Board
{
	public Row[] Rows { get; private set; }

	// Upper Section
	public Row Aces { get; private set; }
	public Row Twos { get; private set; }
	public Row Threes { get; private set; }
	public Row Fours { get; private set; }
	public Row Fives { get; private set; }
	public Row Sixes { get; private set; }

	// Lower Section
	public Row ThreeOfAKind { get; private set; }
	public Row FourOfAKind { get; private set; }
	public Row FullHouse { get; private set; }
	public Row SmallStraight { get; private set; }
	public Row LargeStraight { get; private set; }
	public Row Yahtzee { get; private set; }
	public Row Chance { get; private set; }

	public Row Save { get; private set; }

	public Board()
	{
		Rows = new Row[]
		{
			Aces = new Row("Aces"),
			Twos = new Row("Twos"),
			Threes = new Row("Threes"),
			Fours = new Row("Fours"),
			Fives = new Row("Fives"),
			Sixes =new Row("Sixes"),

			ThreeOfAKind = new Row("Three Of AKind"),
			FourOfAKind =new Row("Four Of AKind"),
			FullHouse = new Row("Full House"),
			SmallStraight = new Row("Small Straight"),
			LargeStraight = new Row("Large Straight"),
			Yahtzee = new Row("Yahtzee"),
			Chance = new Row("Chance")
		};

		Save = new Row("Save");
	}
}
