var game = new Game();
var gui = new GUI(game);
var keyPressed = (ConsoleKey)0;

gui.Welcome();

while (!game.Over())
{
	keyPressed = Console.ReadKey().Key;

	if (keyPressed == ConsoleKey.Spacebar)
	{
		var dices = Game.RollDices();
		gui.PrintDices(dices);
	}
	else if (keyPressed == ConsoleKey.Enter)
	{
		gui.SelectionMode();
	}
	else if (keyPressed == ConsoleKey.UpArrow)
	{
		gui.Select(-1);
	}
	else if (keyPressed == ConsoleKey.DownArrow)
	{
		gui.Select(1);
	}

	gui.Update();
}