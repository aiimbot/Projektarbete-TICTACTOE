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
	*/

	public IPlayer ChooseOpponent(Ruleset rules)
{
    IStrategy win = new LineCompletion(rules, Mark.O);
    IStrategy block = new LineCompletion(rules, Mark.X);
    IStrategy guess = new RandomChoice(random);

    IPlayer[] opponents =
    {
        new HumanPlayer("Spelare 2"),
        new ComputerPlayer(new[] { guess }),
        new ComputerPlayer(new[] { block, guess }),
        new ComputerPlayer(new[] { win, block, guess })
    };

    int choice = prompt.AskNumber(
        "Motståndare: 1 Människa, 2 Lätt, 3 Medel, 4 Svår: ", 1, 4);
    return opponents[choice - 1];
}

	public Board ChooseBoard()
	{
		int size = prompt.AskNumber("Välj brädstorlek: ", 3, 12);
		return new Board(size);
	}
}