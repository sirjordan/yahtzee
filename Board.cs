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

	//public Row Save { get; private set; }

	public Board()
	{
		Rows = new Row[]
		{
			Aces = new Row("Aces" , new ScoreUpper(1)),
			Twos = new Row("Twos" , new ScoreUpper(2)),
			Threes = new Row("Threes" , new ScoreUpper(3)),
			Fours = new Row("Fours" , new ScoreUpper(4)),
			Fives = new Row("Fives" , new ScoreUpper(5)),
			Sixes = new Row("Sixes" , new ScoreUpper(6)),

			ThreeOfAKind = new Row("Three Of A Kind", new NOfAKind(3)),
			FourOfAKind = new Row("Four Of A Kind", new NOfAKind(4)),
			FullHouse = new Row("Full House", new FullHouse()),
			SmallStraight = new Row("Small Straight", new Straight(4)),
			LargeStraight = new Row("Large Straight", new Straight(5)),
			Yahtzee = new Row("Yahtzee", new Yahtzee()),
			Chance = new Row("Chance", new Chance())
		};

		//Save = new Row("Save");
	}
}
