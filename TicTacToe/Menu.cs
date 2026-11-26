public class Menu
{

	private readonly Prompt prompt;
	private readonly Random random;

	public Menu(Prompt prompt, Random randomgi) 
	{
		this.prompt = prompt;
		this.random = random;
	}

	/*
	public void ShowWelcome()
	{

	}

	public Ruleset ChooseRuleset()
	{

	}

	public IPlayer ChooseOpponent()
	{

	}
	*/

	public Board ChooseBoard()
	{
		int size = prompt.AskNumber("Välj brädstorlek: ", 3, 12);
		return new Board(size);
	}
}