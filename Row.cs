internal class Row
{
	private int[] _dices;
	private IScoreAlgorithm _scoreAlgorithm;

	public bool Set { get; private set; }
	public string Name { get; private set; }
	public int[] Dices
	{
		get { return _dices; }
		set 
		{
			if (!Set)
			{
				_dices = value;
				Set = true;
			}
			else
			{
				throw new InvalidOperationException("A row can be set only once");
			}
		}
	}

	public Row(string rowName, IScoreAlgorithm scoreAlgorithm)
	{
		Name = rowName;
		_scoreAlgorithm = scoreAlgorithm;

		Set = false;
		_dices = new int[Rules.NumberOfDices];
	}

	public int CalcScore()
	{
		if (Dices.All(d => d > 0))
		{
			return _scoreAlgorithm.GetScore(Dices);
		}
		else
		{
			return 0;
		}
	}
}
