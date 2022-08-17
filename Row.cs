internal class Row
{
	private int[] _dices;
	private IScoreAlgorithm _scoreAlgorithm;

	public bool IsSet { get; private set; }
	public string Name { get; private set; }
	public int[] Dices
	{
		get { return _dices; }
		set 
		{
			if (!IsSet)
			{
				_dices = value;
				IsSet = true;
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

		IsSet = false;
		_dices = new int[Rules.NumberOfDices];
	}

	public int CalcScore()
	{
		if (IsSet)
		{
			return _scoreAlgorithm.GetScore(Dices);
		}
		else
		{
			return 0;
		}
	}
}
