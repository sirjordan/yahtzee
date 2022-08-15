
Console.WriteLine("Welcome to Yahtzee!");
Console.WriteLine("Press any key to continue...");

var game = new Game();
var gui = new GUI(game);
var keyPressed = (ConsoleKey)0;

while (!game.Over())
{
	keyPressed = Console.ReadKey().Key;

	Console.Clear();
	Console.WriteLine("Yahtzee!");
	Console.WriteLine($"Total: {game.TotalScore}");
	Console.WriteLine();
	gui.PrintBoard();
	
	if (keyPressed == ConsoleKey.Spacebar)
	{
		var dices = game.RollDices();
		gui.PrintDices(dices);
	}
}