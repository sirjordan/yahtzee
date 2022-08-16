var game = new Game();
var gui = new GUI(game);
var keyPressed = (ConsoleKey)0;

gui.Welcome();

while (!game.Over())
{
	keyPressed = Console.ReadKey().Key;

	if (keyPressed == ConsoleKey.Spacebar)
	{
		game.RollDices();
	}
	else if (keyPressed == ConsoleKey.Enter)
	{
		game.TurnSelectionMode();
	}
	else if (keyPressed == ConsoleKey.UpArrow)
	{
		game.Select(-1);
	}
	else if (keyPressed == ConsoleKey.DownArrow)
	{
		game.Select(1);
	}

	gui.Update();
}