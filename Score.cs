
enum LowerSectionCategory
{
	// At least three dice the same
	ThreeOfAKind,
	// At least four dice the same
	FourOfAKind,
	// Three of one number and two of another
	FullHouse,
	// Four sequential dice (1-2-3-4, 2-3-4-5, or 3-4-5-6) 
	SmallStraight,
	// Five sequential dice
	LargeStraight,
	// All five dice the same 
	Yahtzee,
	// Any combination 
	Chance
}

internal class Score
{
	internal static int ScoreUpper(int match, int[] dices)
	{
		// The sum of dice with the number {match}

		if (match < 1 || match > 6)
		{
			throw new ArgumentException($"{match} must be between 1-6");
		}

		var matches = dices.Count(r => r == match);

		return matches * match;
	}

	internal static int ScoreLower(LowerSectionCategory cat, int[] dices)
	{
		switch (cat)
		{
			case LowerSectionCategory.ThreeOfAKind:
				return ScoreNOfAKind(3, dices);
			case LowerSectionCategory.FourOfAKind:
				return ScoreNOfAKind(4, dices);
			case LowerSectionCategory.FullHouse:
				var threeOfANumber = false;
				// Used to exclude in the second check for twos
				var threeOfANumberFound = -1;

				for (int i = 0; i < dices.Length; i++)
				{
					var num = dices[i];
					threeOfANumber = dices.Count(t => t == num) >= 3;

					if (threeOfANumber)
					{
						threeOfANumberFound = num;
						break;
					}
				}

				var twoOfANumber = false;
				for (int i = 0; i < dices.Length; i++)
				{
					var num = dices[i];
					twoOfANumber = (dices.Count(t => t == num) >= 2) && (num != threeOfANumberFound);

					if (twoOfANumber)
					{
						break;
					}
				}

				if (threeOfANumber && twoOfANumber)
				{
					return 25;
				}
				else
				{
					return 0;
				}
			case LowerSectionCategory.SmallStraight:
				var maxSequence = CountSequence(dices);

				if (maxSequence >= 4)
				{
					return 30;
				}
				else
				{
					return 0;
				}
			case LowerSectionCategory.LargeStraight:
				var sequence = CountSequence(dices);

				if (sequence >= 5)
				{
					return 40;
				}
				else
				{
					return 0;
				}
			case LowerSectionCategory.Yahtzee:
				var allTheSame = dices.All(r => r == dices[0]);
				if (allTheSame)
				{
					return 50;
				}
				else
				{
					return 0;
				}
			case LowerSectionCategory.Chance:
				return dices.Sum();
			default:
				return 0;
		}

		int ScoreNOfAKind(int ofAkind, int[] dices)
		{
			var nOfAKind = false;

			for (int i = 0; i < dices.Length; i++)
			{
				var kind = dices[i];
				nOfAKind = dices.Count(t => t == kind) >= ofAkind;

				if (nOfAKind)
				{
					return dices.Sum();
				}
			}

			return 0;
		}

		int CountSequence(int[] dices)
		{
			var dicesCopy = new int[dices.Length];
			Array.Copy(dices, dicesCopy, dices.Length);
			Array.Sort(dicesCopy);  // Accending

			var maxSequence = 1;
			for (int i = 0; i < dicesCopy.Length - 1; i++)
			{
				var current = dicesCopy[i];
				var next = dicesCopy[i + 1];

				if (next - current == 1)
				{
					maxSequence++;
				}
				else
				{
					maxSequence = 1;
				}
			}

			return maxSequence;
		}
	}
}
