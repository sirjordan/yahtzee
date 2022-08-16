internal class Row
{
	public string Name { get; private set; }
	public int[] Dices { get; private set; }

	public Row(string rowName)
	{
		Name = rowName;
		Dices = new int[Rules.NumberOfDices];
	}
}
